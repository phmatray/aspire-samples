using System.Collections.Immutable;

namespace HtmxAppServer.Routes;

public static class Routes
{
    // Define base paths to reduce redundancy
    private const string UiPath = "/ui/pages";
    private const string BlocksPath = "/ui/blocks";

    // UI Pages
    public const string RouteApp = "/";
    public const string RouteDashboard = $"{UiPath}/dashboard";
    public const string RouteWelcome = $"{UiPath}/welcome";
    public const string RouteBills = $"{UiPath}/bills";
    public const string RouteBlank = $"{UiPath}/blank";
    public const string RouteCalendar = $"{UiPath}/calendar";
    public const string RouteCharts = $"{UiPath}/charts";
    public const string RouteIntegration = $"{UiPath}/integration";
    public const string RouteLeads = $"{UiPath}/leads";
    public const string RouteProfileSettings = $"{UiPath}/profile-settings";
    public const string RouteTeam = $"{UiPath}/team";
    public const string RouteTransactions = $"{UiPath}/transactions";

    // Documentation and Auth
    public const string RouteDocComponents = $"{UiPath}/doc-components";
    public const string RouteDocFeatures = $"{UiPath}/doc-features";
    public const string RouteDocumentation = $"{UiPath}/documentation";
    public const string RouteForgotPassword = $"{UiPath}/forgot-password";
    public const string RouteGettingStarted = $"{UiPath}/getting-started";
    public const string RouteLogin = $"{UiPath}/login";
    public const string RouteRegister = $"{UiPath}/register";

    // Error Handling
    public const string RouteCode404 = $"{UiPath}/not-found";

    // UI Blocks
    public const string RouteCounter = $"{BlocksPath}/counter";
    public const string RouteMovieCharacters = $"{BlocksPath}/movie-characters";
    public const string RouteMovieCharactersRows = $"{BlocksPath}/movie-characters-rows";
    
    // DO NOT FORGET TO ADD NEW ROUTES TO RouteData.AllRoutes
    public static ImmutableArray<RouteInfo> GetAllRoutes() =>
    [
        new RouteInfo(RouteApp, "App"),
        new RouteInfo(RouteDashboard, "Dashboard"),
        new RouteInfo(RouteWelcome, "Welcome"),
        new RouteInfo(RouteBills, "Bills"),
        new RouteInfo(RouteBlank, "Blank"),
        new RouteInfo(RouteCalendar, "Calendar"),
        new RouteInfo(RouteCharts, "Charts"),
        new RouteInfo(RouteIntegration, "Integration"),
        new RouteInfo(RouteLeads, "Leads"),
        new RouteInfo(RouteProfileSettings, "Profile Settings"),
        new RouteInfo(RouteTeam, "Team"),
        new RouteInfo(RouteTransactions, "Transactions"),
        new RouteInfo(RouteDocComponents, "Doc Components"),
        new RouteInfo(RouteDocFeatures, "Doc Features"),
        new RouteInfo(RouteDocumentation, "Documentation"),
        new RouteInfo(RouteForgotPassword, "Forgot Password"),
        new RouteInfo(RouteGettingStarted, "Getting Started"),
        new RouteInfo(RouteLogin, "Login"),
        new RouteInfo(RouteRegister, "Register"),
        new RouteInfo(RouteCode404, "Not Found"),
    ];
}