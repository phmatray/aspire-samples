namespace HtmxAppServer.Services;

public interface IRoutingService
{
    string GetCurrentRoute();
    bool IsCurrentRoute(string route);
}

public class RoutingService(IHttpContextAccessor httpContextAccessor) : IRoutingService
{
    public string GetCurrentRoute()
    {
        return httpContextAccessor.HttpContext?.Request.Path ?? "/";
    }
  
    public bool IsCurrentRoute(string route)
    {
        return GetCurrentRoute() == route;
    }
}