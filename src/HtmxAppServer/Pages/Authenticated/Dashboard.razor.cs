namespace HtmxAppServer.Pages.Authenticated;

public class DashboardEndpoint
    : HtmxComponentEndpoint<Dashboard, DashboardEndpoint.DashboardParameters>
{
    public override void Configure()
    {
        Get(RouteDashboard);
        AllowAnonymous();
    }

    public record DashboardParameters
        : HtmxComponentParameters;
}