namespace HtmxAppServer.Features.Documentation.Pages;

public class DocFeaturesEndpoint
    : HtmxComponentEndpoint<DocFeatures, DocFeaturesEndpoint.DocFeaturesParameters>
{
    public override void Configure()
    {
        Get(RouteDocFeatures);
        AllowAnonymous();
    }

    public record DocFeaturesParameters
        : HtmxComponentParameters;
}