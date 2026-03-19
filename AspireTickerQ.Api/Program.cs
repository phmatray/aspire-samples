using AspireTickerQ.Api.Modules;
using TheAppManager.Startup;

AppManager.Start(args, modules =>
{
    modules
        .Add<ServiceDefaultsModule>()
        .Add<OpenApiModule>()
        .Add<UserEndpointsModule>();
});
