using Microsoft.Extensions.Localization;

namespace HtmxAppServer.Services;

public interface ILocalizationService
{
    string GetLocalizedString(string name);
}

public class LocalizationService : ILocalizationService
{
    private readonly IStringLocalizer _localizer;
    
    public LocalizationService(IStringLocalizer<LocalizationService> localizer)
    {
        _localizer = localizer;
    }
    
    public string GetLocalizedString(string name)
    {
        return _localizer[name];
    }
}