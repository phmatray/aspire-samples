global using FastComponents;
global using static HtmxAppServer.Routes.Routes;

using HtmxAppServer.Services;
using HtmxAppServer.Utils;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

// TODO: enable AOT compilation
// TODO: create a Template from this project
// TODO: complete README.md for this project

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddFastComponents();

services.AddHttpContextAccessor();
services.AddSingleton<IErrorBoundaryLogger, CustomErrorBoundaryLogger>();

// Add business services
services.AddSingleton<MovieService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

// Map endpoints to components
app.UseFastComponents();

app.Run();