namespace HtmxAppServer.Routing.Models;

public class SidebarDropdown(string title, string icon)
    : SidebarItem(title, icon)
{
    public List<SidebarLink> Links { get; set; } = [];
}