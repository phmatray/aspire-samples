using Microsoft.Extensions.DependencyInjection;

namespace YellowModule.ApiClient.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection AddYellowApiClient(this IServiceCollection services)
        {
            services
                .AddYellowGraphqlClient()
                .ConfigureHttpClient(client => client.BaseAddress = new Uri("http://yellow-api/graphql"));

            return services;
        }
    }
}