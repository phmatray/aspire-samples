using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace AspireTickerQ.Worker.Services;

public class EmailService : IEmailService
{
    private readonly SmtpSettings _settings;
    private readonly ILogger<EmailService> _logger;

    public EmailService(
        IOptions<SmtpSettings> settings,
        ILogger<EmailService> logger)
    {
        _settings = settings.Value;
        _logger = logger;
    }

    public async Task SendAsync(
        string to,
        string subject,
        string body,
        CancellationToken cancellationToken = default)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(_settings.FromName, _settings.FromEmail));
        message.To.Add(MailboxAddress.Parse(to));
        message.Subject = subject;
        message.Body = new TextPart("plain") { Text = body };

        using var client = new SmtpClient();

        try
        {
            await client.ConnectAsync(
                _settings.Host,
                _settings.Port,
                _settings.UseSsl,
                cancellationToken);

            if (!string.IsNullOrEmpty(_settings.Username))
            {
                await client.AuthenticateAsync(
                    _settings.Username,
                    _settings.Password,
                    cancellationToken);
            }

            await client.SendAsync(message, cancellationToken);
            await client.DisconnectAsync(true, cancellationToken);

            _logger.LogInformation("Email sent successfully to {To}", to);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to send email to {To}", to);
            throw;
        }
    }
}
