using Microsoft.Extensions.DependencyInjection;

namespace YellowModule.ApiClient;

public static class DependencyInjections
{
    public static IServiceCollection AddYellowApiClient(this IServiceCollection services)
    {
        services
            .AddYellowGraphqlClient()
            .ConfigureHttpClient(client => client.BaseAddress = new Uri("http://yellow-api-service/graphql"));
        
        return services;
    }
}