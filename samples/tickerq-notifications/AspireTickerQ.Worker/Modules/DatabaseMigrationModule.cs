using AspireTickerQ.Shared.Data;
using TheAppManager.Modules;
using TickerQ.EntityFrameworkCore.DbContextFactory;

namespace AspireTickerQ.Worker.Modules;

public class DatabaseMigrationModule : IAppModule
{
    public void ConfigureMiddleware(WebApplication app)
    {
        // Apply migrations on startup (development only - use proper deployment strategy in production)
        using var scope = app.Services.CreateScope();

        var appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        appDbContext.Database.EnsureCreatedAsync().GetAwaiter().GetResult();

        var tickerDbContext = scope.ServiceProvider.GetRequiredService<TickerQDbContext>();
        tickerDbContext.Database.EnsureCreatedAsync().GetAwaiter().GetResult();
    }
}
