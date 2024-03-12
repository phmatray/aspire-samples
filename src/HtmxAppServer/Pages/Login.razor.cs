namespace HtmxAppServer.Pages;

public class LoginEndpoint
    : HtmxComponentEndpoint<Login, LoginEndpoint.LoginParameters>
{
    public override void Configure()
    {
        Get(RouteLogin);
        AllowAnonymous();
    }

    public record LoginParameters
        : HtmxComponentParameters;
}