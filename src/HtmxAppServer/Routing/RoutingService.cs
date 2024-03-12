using HtmxAppServer.Routing.Models;
using Microsoft.Extensions.Localization;

namespace HtmxAppServer.Routing;

public class RoutingService(
    IHttpContextAccessor httpContextAccessor,
    IStringLocalizer<RoutingService> localizer)
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

        sidebarItems.AddSidebarSubmenu(
            localizer.GetString("Overview"),
            "Eye", [
                new SidebarLink(
                    RouteGettingStarted,
                    localizer.GetString("Missions"),
                    "ClipboardDocumentCheck"),
                new SidebarLink(
                    RouteGettingStarted,
                    localizer.GetString("Documents"),
                    "DocumentText"),
            ]);

        sidebarItems.AddSidebarSubmenu(
            localizer.GetString("Profile"),
            "Person", [
                new SidebarLink(
                    RouteGettingStarted,
                    localizer.GetString("Addresses"),
                    "MapMarker"),
                new SidebarLink(
                    RouteGettingStarted,
                    localizer.GetString("Nationality"),
                    "Flag"),
                new SidebarLink(
                    RouteGettingStarted,
                    localizer.GetString("IdentificationNumbers"),
                    "Identification"),
                new SidebarLink(
                    RouteGettingStarted,
                    localizer.GetString("LegalRelations"),
                    "UserGroup"),
                new SidebarLink(
                    RouteGettingStarted,
                    localizer.GetString("FamilyAndLineage"),
                    "Users"),
                new SidebarLink(
                    RouteGettingStarted, 
                    localizer.GetString("BCERelations"), 
                    "BuildingOffice"),
                new SidebarLink(
                    RouteGettingStarted,
                    localizer.GetString("LoggingMutations"),
                    "ClipboardDocumentList"),
            ]);

        sidebarItems.AddSidebarSubmenu(
            localizer.GetString("Career"),
            "Briefcase", [
            new SidebarLink(
                RouteGettingStarted,
                localizer.GetString("AffiliationHistory"),
                "History"),
            new SidebarLink(
                RouteGettingStarted,
                localizer.GetString("AssistanceRequests"),
                "Lifebuoy"),
            new SidebarLink(
                RouteGettingStarted,
                localizer.GetString("CareerManagement"),
                "Briefcase"),
            new SidebarLink(
                RouteGettingStarted,
                localizer.GetString("HelpersAndSupported"),
                "HandThumbUp"),
            new SidebarLink(
                RouteGettingStarted,
                localizer.GetString("ContributionsOverview"),
                "CurrencyEuro"),
            new SidebarLink(
                RouteGettingStarted,
                localizer.GetString("EClipz"),
                "Film"),
            new SidebarLink(
                RouteGettingStarted,
                localizer.GetString("EUTransfer"),
                "GlobeEuropeAfrica"),
            new SidebarLink(
                RouteGettingStarted,
                localizer.GetString("Revenues"),
                "CurrencyEuro"),
            new SidebarLink(
                RouteGettingStarted,
                localizer.GetString("PensionEngineCareer"),
                "Car"),
            new SidebarLink(
                RouteGettingStarted,
                localizer.GetString("CareerCertificate"),
                "DocumentCheck"),
        ]);

        return sidebarItems;
    }
}