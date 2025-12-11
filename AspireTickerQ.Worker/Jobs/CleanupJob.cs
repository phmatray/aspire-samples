using AspireTickerQ.Shared.Data;
using Microsoft.EntityFrameworkCore;
using TickerQ.Utilities.Base;

namespace AspireTickerQ.Worker.Jobs;

public class CleanupJob
{
    private readonly AppDbContext _dbContext;
    private readonly ILogger<CleanupJob> _logger;

    public CleanupJob(
        AppDbContext dbContext,
        ILogger<CleanupJob> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    [TickerFunction("CleanupOldNotifications", cronExpression: "0 0 0 * * *")]
    public async Task CleanupOldNotifications(
        TickerFunctionContext context,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting cleanup job for notifications older than 30 days");

        var cutoffDate = DateTime.UtcNow.AddDays(-30);
        var oldNotifications = await _dbContext.Notifications
            .Where(n => n.CreatedAt < cutoffDate)
            .ToListAsync(cancellationToken);

        if (oldNotifications.Any())
        {
            _dbContext.Notifications.RemoveRange(oldNotifications);
            await _dbContext.SaveChangesAsync(cancellationToken);

            _logger.LogInformation(
                "Cleanup completed: removed {Count} notifications",
                oldNotifications.Count);
        }
        else
        {
            _logger.LogInformation("No old notifications to clean up");
        }
    }
}
