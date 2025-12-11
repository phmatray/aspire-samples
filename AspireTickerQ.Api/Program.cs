using AspireTickerQ.Api.Services;
using AspireTickerQ.Shared.Data;
using AspireTickerQ.Shared.DTOs;
using TickerQ.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add SQL Server with Aspire integration
builder.AddSqlServerDbContext<AppDbContext>("appdb");

// Register services
builder.Services.AddScoped<IUserService, UserService>();

// Add TickerQ for scheduling capability (API only schedules, doesn't process)
builder.Services.AddTickerQ();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// User registration endpoint
app.MapPost("/api/users/register", async (
    RegisterRequest request,
    IUserService userService) =>
{
    var user = await userService.RegisterUserAsync(request.Email, request.Name);
    return Results.Ok(new { userId = user.Id });
})
.WithName("RegisterUser");

app.Run();
