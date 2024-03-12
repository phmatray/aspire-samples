using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;

namespace HtmxAppServer;

public static class Localization
{
    private const string DefaultCulture = "nl-BE";
    private const string ResourcesPath = "Resources";

    public static readonly CultureInfo[] SupportedCultures =
    [
        new CultureInfo(DefaultCulture),
        new CultureInfo("fr-BE")
    ];

    public static void AddLocalization(IServiceCollection services)
    {
        services.AddLocalization(options =>
        {
            options.ResourcesPath = ResourcesPath;
        });
        
        services.Configure<RequestLocalizationOptions>(options =>
        {
            options.DefaultRequestCulture = new RequestCulture(DefaultCulture);
            options.SupportedCultures = SupportedCultures;
            options.SupportedUICultures = SupportedCultures;
        });
    }

    public static void UseLocalization(WebApplication app)
    {
        var options = app.Services
            .GetRequiredService<IOptions<RequestLocalizationOptions>>()
            .Value;
        
        app.UseRequestLocalization(options);
    }
}