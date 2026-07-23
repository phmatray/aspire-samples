namespace AspireTickerQ.Shared.DTOs;

public class WelcomeEmailRequest
{
    public string Email { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public Guid UserId { get; set; }
}
