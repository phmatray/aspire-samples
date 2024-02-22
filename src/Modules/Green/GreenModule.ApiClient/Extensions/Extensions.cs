using Microsoft.Extensions.DependencyInjection;

namespace GreenModule.ApiClient.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection AddGreenApiClient(this IServiceCollection services)
        {
            services.AddSingleton<GreenWcfApiClient>();

            return services;
        }
    }
}