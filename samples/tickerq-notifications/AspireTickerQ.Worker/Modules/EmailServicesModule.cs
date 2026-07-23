using AspireTickerQ.Worker.Services;
using TheAppManager.Modules;

namespace AspireTickerQ.Worker.Modules;

public class EmailServicesModule : IAppModule
{
    public void ConfigureServices(WebApplicationBuilder builder)
    {
        // Register email service
        builder.Services.Configure<SmtpSettings>(
            builder.Configuration.GetSection("SmtpSettings"));
        builder.Services.AddScoped<IEmailService, EmailService>();
    }
}
