IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

// var redis = builder.AddRedisContainer("redis");
// var rabbitMq = builder.AddRabbitMQContainer("EventBus");
// var messageBus = builder.AddRabbitMQContainer("messagebus");

// var postgres = builder.AddPostgresContainer("postgres");

// var blueDb = postgres.AddDatabase("BlueDB");
// var greenDb = postgres.AddDatabase("GreenDB");
// var redDb = postgres.AddDatabase("RedDB");
// var yellowDb = postgres.AddDatabase("YellowDB");

// Services
var blueApi = builder
    .AddProject<Projects.BlueModule_ApiService>("blue-api");
    // .WithReference(redis)
    // .WithReference(rabbitMq)
    // .WithReference(blueDb);

var greenApi = builder
    .AddProject<Projects.GreenModule_ApiService>("green-api");
    // .WithReference(redis)
    // .WithReference(rabbitMq)
    // .WithReference(greenDb);

var redApi = builder
    .AddProject<Projects.RedModule_ApiService>("red-api");
    // .WithReference(redis)
    // .WithReference(rabbitMq)
    // .WithReference(redDb);

var yellowApi = builder
    .AddProject<Projects.YellowModule_ApiService>("yellow-api");
    // .WithReference(redis)
    // .WithReference(rabbitMq)
    // .WithReference(yellowDb);

// Reverse Proxies
builder
    .AddProject<Projects.Web_Bff_Gateway>("bff-gateway")
    .WithReference(blueApi)
    .WithReference(greenApi)
    .WithReference(redApi)
    .WithReference(yellowApi);

// var grpcUI = builder
//     .AddContainer("grpcui", "fullstorydev/grpcui")
//     .WithServiceBinding(8080, 8080, "http")
//     .WithEnvironment("GRPCUI_SERVER", redApi.GetEndpoint("red-api"));

// Web Frontend
builder.AddProject<Projects.AspireAppWithMicroFrontends_Web>("webfrontend")
    .WithReference(blueApi)
    .WithReference(greenApi)
    .WithReference(redApi)
    .WithReference(yellowApi);

// Web Shell
builder.AddProject<Projects.WasmShell>("webshell")
    .WithReference(blueApi)
    .WithReference(greenApi)
    .WithReference(redApi)
    .WithReference(yellowApi);

builder.Build().Run();