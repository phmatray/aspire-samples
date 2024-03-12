WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddApplicationServices();

WebApplication app = builder.Build();

app.UseHttpsRedirection();

app.MapDefaultEndpoints();

app.Run();