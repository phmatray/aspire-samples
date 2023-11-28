using Microsoft.Extensions.DependencyInjection;

namespace GreenModule.ApiClient;

public static class DependencyInjections
{
    public static IServiceCollection AddGreenApiClient(this IServiceCollection services)
    {
        return services;
    }
}