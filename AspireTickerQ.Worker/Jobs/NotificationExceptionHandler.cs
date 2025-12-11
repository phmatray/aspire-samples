using System.Net.Mail;
using MailKit.Net.Smtp;
using TickerQ.Utilities.Enums;
using TickerQ.Utilities.Interfaces;

namespace AspireTickerQ.Worker.Jobs;

public class NotificationExceptionHandler : ITickerExceptionHandler
{
    private readonly ILogger<NotificationExceptionHandler> _logger;

    public NotificationExceptionHandler(ILogger<NotificationExceptionHandler> logger)
    {
        _logger = logger;
    }

    public Task HandleExceptionAsync(
        Exception exception,
        Guid tickerId,
        TickerType tickerType)
    {
        _logger.LogError(
            exception,
            "Job {TickerId} ({TickerType}) failed with error: {Message}",
            tickerId, tickerType, exception.Message);

        // For SMTP errors, log critical alert
        if (exception is SmtpException)
        {
            _logger.LogCritical(
                "SMTP service failure detected for job {TickerId}. Email delivery interrupted.",
                tickerId);

            // In production, integrate with alerting service (PagerDuty, Slack, etc.)
            // await _alertService.SendAlertAsync("Email Service Failure", exception.ToString());
        }

        return Task.CompletedTask;
    }

    public Task HandleCanceledExceptionAsync(
        Exception exception,
        Guid tickerId,
        TickerType tickerType)
    {
        _logger.LogWarning(
            "Job {TickerId} ({TickerType}) was canceled: {Message}",
            tickerId, tickerType, exception.Message);

        return Task.CompletedTask;
    }
}
