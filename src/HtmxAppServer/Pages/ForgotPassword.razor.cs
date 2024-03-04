namespace HtmxAppServer.Pages;

public class ForgotPasswordEndpoint
    : HtmxComponentEndpoint<ForgotPassword, ForgotPasswordEndpoint.ForgotPasswordParameters>
{
    public override void Configure()
    {
        Get(RouteForgotPassword);
        AllowAnonymous();
    }

    public record ForgotPasswordParameters
        : HtmxComponentParameters;
}