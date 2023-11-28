using Microsoft.Extensions.DependencyInjection;

namespace RedModule.ApiClient;

public static class DependencyInjections
{
    public static IServiceCollection AddRedApiClient(this IServiceCollection services)
    {
        return services;
    }
}