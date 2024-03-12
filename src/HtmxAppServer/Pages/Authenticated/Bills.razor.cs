namespace HtmxAppServer.Pages.Authenticated;

public class BillsEndpoint
    : HtmxComponentEndpoint<Bills, BillsEndpoint.BillsParameters>
{
    public override void Configure()
    {
        Get(RouteBills);
        AllowAnonymous();
    }

    public record BillsParameters
        : HtmxComponentParameters;
}