using HtmxAppServer.Routing.Models;
using HtmxAppServer.Services;

namespace HtmxAppServer.Routing;

public interface IRoutingService
{
    string GetCurrentRoute();
    bool IsCurrentRoute(string route);
}

public class RoutingService(
    IHttpContextAccessor httpContextAccessor,
    ILocalizationService localizationService)
    : IRoutingService
{
    public string GetCurrentRoute()
    {
        return httpContextAccessor.HttpContext?.Request.Path ?? "/";
    }
  
    public bool IsCurrentRoute(string route)
    {
        return GetCurrentRoute() == route;
    }

    public SidebarItemCollection GetSidebarItems()
    {
        var sidebarItems = new SidebarItemCollection();
            
        // sidebarItems.AddSidebarLink(RouteDashboard, "Dashboard", "Squares2X2");
        // sidebarItems.AddSidebarLink(RouteLeads, "Leads", "InboxArrowDown");
        // sidebarItems.AddSidebarLink(RouteTransactions, "Transactions", "CurrencyDollar");
        // sidebarItems.AddSidebarLink(RouteCharts, "Analytics", "ChartBar");
        // sidebarItems.AddSidebarLink(RouteIntegration, "Integration", "Bolt");
        // sidebarItems.AddSidebarLink(RouteCalendar, "Calendar", "CalendarDays");
        
        // sidebarItems.AddSidebarSubmenu("Settings", "Cog6Tooth", [
        //     new SidebarLink(RouteProfileSettings, "Profile", "User"),
        //     new SidebarLink(RouteBills, "Billing", "Wallet"),
        //     new SidebarLink(RouteTeam, "Team Members", "Users")
        // ]);
        //
        // sidebarItems.AddSidebarSubmenu("Pages", "DocumentDuplicate", [
        //     new SidebarLink(RouteLogin, "Login", "ArrowRightOnRectangle"),
        //     new SidebarLink(RouteRegister, "Register", "User"),
        //     new SidebarLink(RouteForgotPassword, "Forgot Password", "Key"),
        //     new SidebarLink(RouteBlank, "Blank Page", "Document"),
        //     new SidebarLink(RouteCode404, "404", "ExclamationTriangle")
        // ]);
        //
        // sidebarItems.AddSidebarSubmenu("Documentation", "DocumentText", [
        //     new SidebarLink(RouteGettingStarted, "Getting Started", "DocumentText"),
        //     new SidebarLink(RouteDocFeatures, "Features", "TableCells"),
        //     new SidebarLink(RouteDocComponents, "Components", "CodeBracketSquare")
        // ]);
        
        sidebarItems.AddSidebarSubmenu(localizationService.GetLocalizedString("Hello"), "Eye", [
            new SidebarLink(RouteGettingStarted, "Missions", "ClipboardDocumentCheck"),
            new SidebarLink(RouteGettingStarted, "Documents", "DocumentText"),
        ]);
        
        sidebarItems.AddSidebarSubmenu("Profil", "Person", [
            new SidebarLink(RouteGettingStarted, "Adresses", "MapMarker"),
            new SidebarLink(RouteGettingStarted, "Nationalité", "Flag"),
            new SidebarLink(RouteGettingStarted, "Numéros d'identification", "Identification"),
            new SidebarLink(RouteGettingStarted, "Relations légales", "UserGroup"),
            new SidebarLink(RouteGettingStarted, "Famille et filiation", "Users"),
            new SidebarLink(RouteGettingStarted, "Relations BCE", "BuildingOffice"),
            new SidebarLink(RouteGettingStarted, "Logging Mutations", "ClipboardDocumentList"),
        ]);

        sidebarItems.AddSidebarSubmenu("Carrière", "Briefcase", [
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
            
        return sidebarItems;
    }
}