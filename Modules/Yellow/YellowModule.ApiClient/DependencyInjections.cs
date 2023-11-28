using Microsoft.Extensions.DependencyInjection;

namespace YellowModule.ApiClient;

public static class DependencyInjections
{
    public static IServiceCollection AddYellowApiClient(this IServiceCollection services)
    {
        return services;
    }
}