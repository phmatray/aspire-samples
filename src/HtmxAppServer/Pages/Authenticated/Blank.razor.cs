namespace HtmxAppServer.Pages.Authenticated;

public class BlankEndpoint
    : HtmxComponentEndpoint<Blank, BlankEndpoint.BlankParameters>
{
    public override void Configure()
    {
        Get(RouteBlank);
        AllowAnonymous();
    }

    public record BlankParameters
        : HtmxComponentParameters;
}