using HtmxAppServer.Routing.Models;

namespace HtmxAppServer.Routing;

public interface IRoutingService
{
    string GetCurrentRoute();
    bool IsCurrentRoute(string route);
    SidebarItemCollection GetSidebarItems();
}