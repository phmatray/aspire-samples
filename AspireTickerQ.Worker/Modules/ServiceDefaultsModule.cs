using AspireTickerQ.Shared.Data;
using TheAppManager.Modules;

namespace AspireTickerQ.Worker.Modules;

public class ServiceDefaultsModule : IAppModule
{
    public void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.AddServiceDefaults();

        // Add application database
        builder.AddSqlServerDbContext<AppDbContext>("appdb");
    }

    public void ConfigureMiddleware(WebApplication app)
    {
        // Map Aspire health endpoints
        app.MapDefaultEndpoints();
    }
}
