using AspireTickerQ.Shared.DTOs;
using AspireTickerQ.Worker.Services;
using TickerQ.Utilities;
using TickerQ.Utilities.Base;

namespace AspireTickerQ.Worker.Jobs;

public class WelcomeEmailJob
{
    private readonly IEmailService _emailService;
    private readonly ILogger<WelcomeEmailJob> _logger;

    public WelcomeEmailJob(
        IEmailService emailService,
        ILogger<WelcomeEmailJob> logger)
    {
        _emailService = emailService;
        _logger = logger;
    }

    [TickerFunction("SendWelcomeEmail")]
    public async Task SendWelcomeEmail(
        TickerFunctionContext context,
        CancellationToken cancellationToken)
    {
        var request = await TickerRequestProvider.GetRequestAsync<WelcomeEmailRequest>(
            context, cancellationToken);

        _logger.LogInformation(
            "Processing welcome email for user {UserId}: {Email}",
            request.UserId, request.Email);

        await _emailService.SendAsync(
            to: request.Email,
            subject: "Welcome to TickerQ!",
            body: $"Hello {request.Name},\n\n" +
                  $"Welcome to our platform! We're excited to have you on board.\n\n" +
                  $"Your account has been created successfully.\n\n" +
                  $"Best regards,\nThe TickerQ Team",
            cancellationToken);

        _logger.LogInformation("Welcome email sent successfully to {Email}", request.Email);
    }
}
