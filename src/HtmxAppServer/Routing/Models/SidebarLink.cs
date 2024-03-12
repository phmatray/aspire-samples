namespace HtmxAppServer.Routing.Models;

public class SidebarLink(string path, string title, string icon)
    : SidebarItem(title, icon)
{
    public string Path { get; set; } = path;
}