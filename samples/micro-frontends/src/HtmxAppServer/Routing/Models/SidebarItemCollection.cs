namespace HtmxAppServer.Routing.Models;

public class SidebarItemCollection : List<SidebarItem>
{
    private void AddSidebarLink(string path, string title, string icon)
    {
        Add(new SidebarLink(path, title, icon));
    }

    public void AddSidebarSubmenu(string title, string icon, List<SidebarLink> links)
    {
        Add(new SidebarDropdown(title, icon) { Links = links });
    }
}