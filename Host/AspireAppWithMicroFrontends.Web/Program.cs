using AspireAppWithMicroFrontends.Web;
using AspireAppWithMicroFrontends.Web.Components;
using AspireAppWithMicroFrontends.Web.Extensions;
using BlueModule.ApiClient;
using GreenModule.ApiClient;
using RedModule.ApiClient;
using YellowModule.ApiClient;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
IServiceCollection services = builder.Services;
IWebHostEnvironment environment = builder.Environment;

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
services
    .AddRazorComponents()
    .AddInteractiveServerComponents();

services.AddOutputCache();

// Add Module API Clients
services.AddBlueApiClient();
services.AddGreenApiClient();
services.AddRedApiClient();
services.AddYellowApiClient();

WebApplication app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();

app.UseAntiforgery();

app.UseOutputCache();

app.MapRazorComponents<App>()
    .AddAdditionalAssemblies(
        typeof(BlueModule.Web.Components.HelloBlue).Assembly,
        typeof(GreenModule.Web.Components.HelloGreen).Assembly,
        typeof(RedModule.Web.Components.HelloRed).Assembly,
        typeof(YellowModule.Web.Components.HelloYellow).Assembly)
    // .AddModulesFromAssemblies(environment)
    .AddInteractiveServerRenderMode();

app.MapDefaultEndpoints();

app.Run();