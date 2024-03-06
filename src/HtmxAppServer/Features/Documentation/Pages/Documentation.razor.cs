namespace HtmxAppServer.Features.Documentation.Pages;

public class DocumentationEndpoint
    : HtmxComponentEndpoint<Documentation, DocumentationEndpoint.DocumentationParameters>
{
    public override void Configure()
    {
        Get(RouteDocumentation);
        AllowAnonymous();
    }

    public record DocumentationParameters
        : HtmxComponentParameters;
}