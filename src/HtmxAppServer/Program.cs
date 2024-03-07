global using FastComponents;
global using static HtmxAppServer.Routing.Routes;
using HtmxAppServer.Routing;
using HtmxAppServer.Services;
using HtmxAppServer.Utils;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;

// TODO: enable AOT compilation
// TODO: create a Template from this project
// TODO: complete README.md for this project

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddFastComponents();

services.AddHttpContextAccessor();
services.AddTransient<IRoutingService, RoutingService>();

// Configure localization
services.AddLocalization(options => options.ResourcesPath = "Resources");
services.AddSingleton<IStringLocalizer, StringLocalizer<LocalizationService>>();
services.AddTransient<ILocalizationService, LocalizationService>();

services.AddSingleton<IErrorBoundaryLogger, CustomErrorBoundaryLogger>();

// Add business services
services.AddSingleton<MovieService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

// Localization
var supportedCultures = new[] { "fr-BE", "nl-BE" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

// Map endpoints to components
app.UseFastComponents();

app.Run();