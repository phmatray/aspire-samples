namespace HtmxAppServer.Pages.Authenticated;

public class WelcomeEndpoint
    : HtmxComponentEndpoint<Welcome, WelcomeEndpoint.WelcomeParameters>
{
    public override void Configure()
    {
        Get(RouteWelcome);
        AllowAnonymous();
    }

    public record WelcomeParameters
        : HtmxComponentParameters;
}