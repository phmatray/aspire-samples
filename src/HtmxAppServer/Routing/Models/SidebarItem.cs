namespace HtmxAppServer.Routing.Models;

public abstract class SidebarItem(string title, string icon)
{
    public string Title { get; set; } = title;
    public string Icon { get; set; } = icon;
    
    public string Key
        => Title.Replace(" ", "").ToLower();
}