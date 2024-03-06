namespace HtmxAppServer.Features.Documentation.Pages;

public class GettingStartedEndpoint
    : HtmxComponentEndpoint<DocGettingStarted, GettingStartedEndpoint.GettingStartedParameters>
{
    public override void Configure()
    {
        Get(RouteGettingStarted);
        AllowAnonymous();
    }

    public record GettingStartedParameters
        : HtmxComponentParameters;
}