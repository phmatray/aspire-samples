using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;

namespace HtmxAppServer;

public static class Localization
{
    private const string DefaultCulture = "nl-BE";

    public static readonly CultureInfo[] SupportedCultures =
    [
        new CultureInfo(DefaultCulture),
        new CultureInfo("fr-BE")
    ];

    public static void AddLocalization(this IServiceCollection services)
    {
        services.AddLocalization(options => options.ResourcesPath = "Resources");
        
        services.Configure<RequestLocalizationOptions>(options =>
        {
            options.DefaultRequestCulture = new RequestCulture(DefaultCulture);
            options.SupportedCultures = SupportedCultures;
            options.SupportedUICultures = SupportedCultures;
        });
    }

    public static void UseRequestLocalization(this WebApplication app)
    {
        var options = app.Services
            .GetRequiredService<IOptions<RequestLocalizationOptions>>()
            .Value;
        
        app.UseRequestLocalization(options);
    }
}