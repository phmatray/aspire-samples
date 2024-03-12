namespace HtmxAppServer.Pages.Authenticated;

public class LeadsEndpoint
    : HtmxComponentEndpoint<Leads, LeadsEndpoint.LeadsParameters>
{
    public override void Configure()
    {
        Get(RouteLeads);
        AllowAnonymous();
    }

    public record LeadsParameters
        : HtmxComponentParameters;
}