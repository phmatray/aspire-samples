namespace HtmxAppServer.Routes;

public record RouteInfo(
    string Path,
    string Name,
    string? Icon = null);