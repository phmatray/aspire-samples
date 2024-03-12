using RedModule.ApiService.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Add GRPC Services
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

WebApplication app = builder.Build();
IWebHostEnvironment env = app.Environment;

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();

app.MapGet("/",
    ()
        => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

if (env.IsDevelopment())
{
    app.MapGrpcReflectionService();
}

app.Run();