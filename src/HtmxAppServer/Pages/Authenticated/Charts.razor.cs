namespace HtmxAppServer.Pages.Authenticated;

public class ChartsEndpoint
    : HtmxComponentEndpoint<Charts, ChartsEndpoint.ChartsParameters>
{
    public override void Configure()
    {
        Get(RouteCharts);
        AllowAnonymous();
    }

    public record ChartsParameters
        : HtmxComponentParameters;
}