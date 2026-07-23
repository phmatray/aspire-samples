using AspireTickerQ.Worker.Modules;
using TheAppManager.Startup;

AppManager.Start(args, modules =>
{
    modules
        .Add<ServiceDefaultsModule>()
        .Add<EmailServicesModule>()
        .Add<TickerQModule>()
        .Add<DatabaseMigrationModule>();
});
