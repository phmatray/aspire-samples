using AspireTickerQ.Shared.Data;
using AspireTickerQ.Worker.Jobs;
using AspireTickerQ.Worker.Services;
using Microsoft.EntityFrameworkCore;
using TickerQ.DependencyInjection;
using TickerQ.EntityFrameworkCore;
using TickerQ.EntityFrameworkCore.DbContextFactory;
using TickerQ.EntityFrameworkCore.DependencyInjection;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();

// Add application database
builder.AddSqlServerDbContext<AppDbContext>("appdb");

// Register email service
builder.Services.Configure<SmtpSettings>(
    builder.Configuration.GetSection("SmtpSettings"));
builder.Services.AddScoped<IEmailService, EmailService>();

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

var host = builder.Build();

// Apply migrations on startup (development only - use proper deployment strategy in production)
using (var scope = host.Services.CreateScope())
{
    var appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await appDbContext.Database.EnsureCreatedAsync();

    var tickerDbContext = scope.ServiceProvider.GetRequiredService<TickerQDbContext>();
    await tickerDbContext.Database.EnsureCreatedAsync();
}

host.Run();
