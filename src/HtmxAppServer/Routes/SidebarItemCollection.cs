namespace HtmxAppServer.Routes;

public abstract class SidebarItem(string title, string icon)
{
    public string Title { get; set; } = title;
    public string Icon { get; set; } = icon;
    
    public string Key
        => Title.Replace(" ", "").ToLower();
}

public class SidebarLink(string path, string title, string icon)
    : SidebarItem(title, icon)
{
    public string Path { get; set; } = path;
}

public class SidebarDropdown(string title, string icon)
    : SidebarItem(title, icon)
{
    public List<SidebarLink> Links { get; set; } = [];
}


public class SidebarItemCollection : List<SidebarItem>
{
    public SidebarItemCollection()
    {
        // AddSidebarLink(RouteDashboard, "Dashboard", "Squares2X2");
        // AddSidebarLink(RouteLeads, "Leads", "InboxArrowDown");
        // AddSidebarLink(RouteTransactions, "Transactions", "CurrencyDollar");
        // AddSidebarLink(RouteCharts, "Analytics", "ChartBar");
        // AddSidebarLink(RouteIntegration, "Integration", "Bolt");
        // AddSidebarLink(RouteCalendar, "Calendar", "CalendarDays");
        
        // AddSidebarSubmenu("Settings", "Cog6Tooth", [
        //     new SidebarLink(RouteProfileSettings, "Profile", "User"),
        //     new SidebarLink(RouteBills, "Billing", "Wallet"),
        //     new SidebarLink(RouteTeam, "Team Members", "Users")
        // ]);
        //
        // AddSidebarSubmenu("Pages", "DocumentDuplicate", [
        //     new SidebarLink(RouteLogin, "Login", "ArrowRightOnRectangle"),
        //     new SidebarLink(RouteRegister, "Register", "User"),
        //     new SidebarLink(RouteForgotPassword, "Forgot Password", "Key"),
        //     new SidebarLink(RouteBlank, "Blank Page", "Document"),
        //     new SidebarLink(RouteCode404, "404", "ExclamationTriangle")
        // ]);
        //
        // AddSidebarSubmenu("Documentation", "DocumentText", [
        //     new SidebarLink(RouteGettingStarted, "Getting Started", "DocumentText"),
        //     new SidebarLink(RouteDocFeatures, "Features", "TableCells"),
        //     new SidebarLink(RouteDocComponents, "Components", "CodeBracketSquare")
        // ]);
        
        AddSidebarSubmenu("Aperçu", "Eye", [
            new SidebarLink(RouteGettingStarted, "Missions", "ClipboardDocumentCheck"),
            new SidebarLink(RouteGettingStarted, "Documents", "DocumentText"),
        ]);
        
        AddSidebarSubmenu("Profil", "Person", [
            new SidebarLink(RouteGettingStarted, "Adresses", "MapMarker"),
            new SidebarLink(RouteGettingStarted, "Nationalité", "Flag"),
            new SidebarLink(RouteGettingStarted, "Numéros d'identification", "Identification"),
            new SidebarLink(RouteGettingStarted, "Relations légales", "UserGroup"),
            new SidebarLink(RouteGettingStarted, "Famille et filiation", "Users"),
            new SidebarLink(RouteGettingStarted, "Relations BCE", "BuildingOffice"),
            new SidebarLink(RouteGettingStarted, "Logging Mutations", "ClipboardDocumentList"),
        ]);

        AddSidebarSubmenu("Carrière", "Briefcase", [
            new SidebarLink(RouteGettingStarted, "Historique des affiliations", "History"),
            new SidebarLink(RouteGettingStarted, "Demandes d'aide", "Lifebuoy"),
            new SidebarLink(RouteGettingStarted, "Carrière en gestion", "Briefcase"),
            new SidebarLink(RouteGettingStarted, "Aidants et aidés", "HandThumbUp"),
            new SidebarLink(RouteGettingStarted, "Aperçu de cotisations", "CurrencyEuro"),
            new SidebarLink(RouteGettingStarted, "E-Clipz", "Film"),
            new SidebarLink(RouteGettingStarted, "Transfert EU", "GlobeEuropeAfrica"),
            new SidebarLink(RouteGettingStarted, "Revenus", "CurrencyEuro"),
            new SidebarLink(RouteGettingStarted, "Carrière Moteur Pension", "Car"),
            new SidebarLink(RouteGettingStarted, "Attestation de carrière", "DocumentCheck"),
        ]);
    }

    private void AddSidebarLink(string path, string title, string icon)
    {
        Add(new SidebarLink(path, title, icon));
    }
    
    private void AddSidebarSubmenu(string title, string icon, List<SidebarLink> links)
    {
        Add(new SidebarDropdown(title, icon) { Links = links });
    }
}