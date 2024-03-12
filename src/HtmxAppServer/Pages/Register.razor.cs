namespace HtmxAppServer.Pages;

public class RegisterEndpoint
    : HtmxComponentEndpoint<Register, RegisterEndpoint.RegisterParameters>
{
    public override void Configure()
    {
        Get(RouteRegister);
        AllowAnonymous();
    }

    public record RegisterParameters
        : HtmxComponentParameters;
}