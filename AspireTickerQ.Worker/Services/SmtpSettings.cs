namespace AspireTickerQ.Worker.Services;

public class SmtpSettings
{
    public string Host { get; set; } = "localhost";
    public int Port { get; set; } = 1025;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool UseSsl { get; set; } = false;
    public string FromEmail { get; set; } = "noreply@tickerq.local";
    public string FromName { get; set; } = "TickerQ Notifications";
}
