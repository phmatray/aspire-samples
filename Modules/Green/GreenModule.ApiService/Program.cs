WebApplicationBuilder builder = WebApplication.CreateBuilder();
IServiceCollection services = builder.Services;

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// WCF Service
services.AddServiceModelServices();
services.AddServiceModelMetadata();
services.AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();

WebApplication app = builder.Build();

app.UseServiceModel(serviceBuilder =>
{
    serviceBuilder.AddService<Service>();
    serviceBuilder.AddServiceEndpoint<Service, IService>(new BasicHttpBinding(), "/Service.svc");

    ServiceMetadataBehavior serviceMetadataBehavior = app.Services.GetRequiredService<ServiceMetadataBehavior>();
    serviceMetadataBehavior.HttpsGetEnabled = true;
});

app.Run();