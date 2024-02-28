namespace HtmxAppServer.Pages.Authenticated;

public class TeamEndpoint
    : HtmxComponentEndpoint<Team, TeamEndpoint.TeamParameters>
{
    public override void Configure()
    {
        Get(RouteTeam);
        AllowAnonymous();
    }

    public record TeamParameters
        : HtmxComponentParameters;
}