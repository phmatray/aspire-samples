namespace HtmxAppServer.Pages.Authenticated;

public class ProfileSettingsEndpoint
    : HtmxComponentEndpoint<ProfileSettings, ProfileSettingsEndpoint.ProfileSettingsParameters>
{
    public override void Configure()
    {
        Get(RouteProfileSettings);
        AllowAnonymous();
    }

    public record ProfileSettingsParameters
        : HtmxComponentParameters;
}