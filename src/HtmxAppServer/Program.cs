global using FastComponents;
global using static HtmxAppServer.Routing.Routes;
using HtmxAppServer;
using HtmxAppServer.Routing;
using HtmxAppServer.Services;
using HtmxAppServer.Utils;
using Microsoft.AspNetCore.Components.Web;

// TODO: enable AOT compilation
// TODO: create a Template from this project
// TODO: complete README.md for this project

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddFastComponents();

services.AddHttpContextAccessor();
services.AddTransient<IRoutingService, RoutingService>();

// Configure localization
Localization.AddLocalization(services);
// services.AddSingleton<IStringLocalizer, StringLocalizer<LocalizationService>>();
// services.AddTransient<ILocalizationService, LocalizationService>();

services.AddSingleton<IErrorBoundaryLogger, CustomErrorBoundaryLogger>();

// Add business services
services.AddSingleton<MovieService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

// Localization
app.UseRequestLocalization();

// Map endpoints to components
app.UseFastComponents();

app.Run();