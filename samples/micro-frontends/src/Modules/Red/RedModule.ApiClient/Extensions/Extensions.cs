using Microsoft.Extensions.DependencyInjection;

namespace RedModule.ApiClient.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection AddRedApiClient(this IServiceCollection services)
        {
            services.AddSingleton<RedGrpcApiClient>();

            services.AddGrpcClient<Greeter.GreeterClient>(options =>
            {
                options.Address = new Uri("http://red-api");
            });

            return services;
        }
    }
}