namespace HtmxAppServer.Pages.Authenticated;

public class Code404Endpoint
    : HtmxComponentEndpoint<Code404, Code404Endpoint.Code404Parameters>
{
    public override void Configure()
    {
        Get(RouteCode404);
        AllowAnonymous();
    }

    public record Code404Parameters
        : HtmxComponentParameters;
}