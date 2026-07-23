using AspireTickerQ.Worker.Jobs;
using Microsoft.EntityFrameworkCore;
using TheAppManager.Modules;
using TickerQ.DependencyInjection;
using TickerQ.EntityFrameworkCore;
using TickerQ.EntityFrameworkCore.DbContextFactory;
using TickerQ.EntityFrameworkCore.DependencyInjection;

namespace AspireTickerQ.Worker.Modules;

public class TickerQModule : IAppModule
{
    public void ConfigureServices(WebApplicationBuilder builder)
    {
        // Add TickerQ with full configuration
        builder.Services.AddTickerQ(options =>
        {
            options.ConfigureScheduler(schedulerOptions =>
            {
                schedulerOptions.MaxConcurrency = 10;
                schedulerOptions.NodeIdentifier = Environment.MachineName;
            });

            // Custom exception handler
            options.SetExceptionHandler<NotificationExceptionHandler>();

            // Operational store with separate database
            options.AddOperationalStore(efOptions =>
            {
                efOptions.UseTickerQDbContext<TickerQDbContext>(optionsBuilder =>
                {
                    var connectionString = builder.Configuration.GetConnectionString("tickerqdb");
                    optionsBuilder.UseSqlServer(
                        connectionString,
                        cfg => cfg.EnableRetryOnFailure(
                            maxRetryCount: 3,
                            maxRetryDelay: TimeSpan.FromSeconds(5),
                            errorNumbersToAdd: null)
                    );
                });
            });
        });

        // Register job function classes
        builder.Services.AddScoped<WelcomeEmailJob>();
        builder.Services.AddScoped<DailyDigestJob>();
        builder.Services.AddScoped<CleanupJob>();
    }

    public void ConfigureMiddleware(WebApplication app)
    {
        // Activate TickerQ (includes dashboard and job processing)
        app.UseTickerQ();
    }
}
