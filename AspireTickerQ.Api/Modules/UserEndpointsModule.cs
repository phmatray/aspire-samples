using AspireTickerQ.Api.Services;
using AspireTickerQ.Shared.DTOs;
using TheAppManager.Modules;

namespace AspireTickerQ.Api.Modules;

public class UserEndpointsModule : IAppModule
{
    public void ConfigureEndpoints(IEndpointRouteBuilder endpoints)
    {
        // User registration endpoint
        endpoints.MapPost("/api/users/register", async (
            RegisterRequest request,
            IUserService userService) =>
        {
            var user = await userService.RegisterUserAsync(request.Email, request.Name);
            return Results.Ok(new { userId = user.Id });
        })
        .WithName("RegisterUser");
    }
}
