namespace HtmxAppServer.Pages;

public class DocComponentsEndpoint
    : HtmxComponentEndpoint<DocComponents, DocComponentsEndpoint.DocComponentsParameters>
{
    public override void Configure()
    {
        Get(RouteDocComponents);
        AllowAnonymous();
    }

    public record DocComponentsParameters
        : HtmxComponentParameters;
}