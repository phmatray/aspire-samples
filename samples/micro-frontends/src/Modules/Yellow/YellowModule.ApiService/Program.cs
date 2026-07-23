using YellowModule.ApiService.Queries;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<GetBookQuery>();

WebApplication app = builder.Build();

app.MapGraphQL();

app.Run();