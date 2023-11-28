IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedisContainer("cache");
var db = builder.AddPostgresContainer("db");

// Blue Modules
var blueApiService = builder
    .AddProject<Projects.BlueModule_ApiService>("blue-api-service");

// Green Modules
var greenApiService = builder
    .AddProject<Projects.GreenModule_ApiService>("green-api-service");

// Red Modules
var redApiService = builder
    .AddProject<Projects.RedModule_ApiService>("red-api-service");

// Yellow Modules
var yellowApiService = builder
    .AddProject<Projects.YellowModule_ApiService>("yellow-api-service");

// Web Frontend
builder.AddProject<Projects.AspireAppWithMicroFrontends_Web>("webfrontend")
    .WithReference(blueApiService)
    .WithReference(greenApiService)
    .WithReference(redApiService)
    .WithReference(yellowApiService);

builder.Build().Run();