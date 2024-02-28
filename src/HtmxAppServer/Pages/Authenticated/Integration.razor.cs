namespace HtmxAppServer.Pages.Authenticated;

public class IntegrationEndpoint
    : HtmxComponentEndpoint<Integration, IntegrationEndpoint.IntegrationParameters>
{
    public override void Configure()
    {
        Get(RouteIntegration);
        AllowAnonymous();
    }

    public record IntegrationParameters
        : HtmxComponentParameters;
}