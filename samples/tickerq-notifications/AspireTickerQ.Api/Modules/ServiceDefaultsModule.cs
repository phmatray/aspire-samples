using AspireTickerQ.Api.Services;
using AspireTickerQ.Shared.Data;
using TheAppManager.Modules;
using TickerQ.DependencyInjection;

namespace AspireTickerQ.Api.Modules;

public class ServiceDefaultsModule : IAppModule
{
    public void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.AddServiceDefaults();

        // Add SQL Server with Aspire integration
        builder.AddSqlServerDbContext<AppDbContext>("appdb");

        // Register services
        builder.Services.AddScoped<IUserService, UserService>();

        // Add TickerQ for scheduling capability (API only schedules, doesn't process)
        builder.Services.AddTickerQ();
    }

    public void ConfigureMiddleware(WebApplication app)
    {
        app.MapDefaultEndpoints();
        app.UseHttpsRedirection();
    }
}
