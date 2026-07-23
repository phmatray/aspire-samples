using AspireTickerQ.Shared.Data;
using AspireTickerQ.Shared.Models;
using AspireTickerQ.Worker.Services;
using Microsoft.EntityFrameworkCore;
using TickerQ.Utilities.Base;

namespace AspireTickerQ.Worker.Jobs;

public class DailyDigestJob
{
    private readonly AppDbContext _dbContext;
    private readonly IEmailService _emailService;
    private readonly ILogger<DailyDigestJob> _logger;

    public DailyDigestJob(
        AppDbContext dbContext,
        IEmailService emailService,
        ILogger<DailyDigestJob> logger)
    {
        _dbContext = dbContext;
        _emailService = emailService;
        _logger = logger;
    }

    [TickerFunction("SendDailyDigest", cronExpression: "0 0 9 * * *")]
    public async Task SendDailyDigest(
        TickerFunctionContext context,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting daily digest job");

        var users = await _dbContext.Users.ToListAsync(cancellationToken);
        var yesterday = DateTime.UtcNow.AddDays(-1);

        foreach (var user in users)
        {
            var notifications = await _dbContext.Notifications
                .Where(n => n.UserId == user.Id && n.CreatedAt >= yesterday)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync(cancellationToken);

            if (notifications.Any())
            {
                var digestBody = FormatDigest(user.Name, notifications);

                await _emailService.SendAsync(
                    to: user.Email,
                    subject: "Daily Digest - Your Notifications Summary",
                    body: digestBody,
                    cancellationToken);

                _logger.LogInformation(
                    "Daily digest sent to {Email} with {Count} notifications",
                    user.Email, notifications.Count);
            }
        }

        _logger.LogInformation("Daily digest job completed for {UserCount} users", users.Count);
    }

    private static string FormatDigest(string userName, List<Notification> notifications)
    {
        var body = $"Hello {userName},\n\n";
        body += $"Here's your daily summary of {notifications.Count} notification(s):\n\n";

        foreach (var notification in notifications)
        {
            body += $"- [{notification.CreatedAt:yyyy-MM-dd HH:mm}] {notification.Message}\n";
        }

        body += "\n\nBest regards,\nThe TickerQ Team";
        return body;
    }
}
