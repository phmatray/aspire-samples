namespace HtmxAppServer.Pages;

public class GettingStartedEndpoint
    : HtmxComponentEndpoint<GettingStarted, GettingStartedEndpoint.GettingStartedParameters>
{
    public override void Configure()
    {
        Get(RouteGettingStarted);
        AllowAnonymous();
    }

    public record GettingStartedParameters
        : HtmxComponentParameters;
}