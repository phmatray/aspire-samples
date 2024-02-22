using AspireAppWithMicroFrontends.Web.Components;
using AspireAppWithMicroFrontends.Web.Extensions;
using MudBlazor.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
IServiceCollection services = builder.Services;

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
services
    .AddRazorComponents()
    .AddInteractiveServerComponents();

// Add MudBlazor
services.AddMudServices();

services.AddOutputCache();

builder.AddApplicationServices();

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
    .AddInteractiveServerRenderMode();

app.MapDefaultEndpoints();

app.Run();