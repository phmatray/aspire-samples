using Microsoft.Extensions.DependencyInjection;

namespace BlueModule.ApiClient.Extensions;

public static class Extensions
{
    public static IServiceCollection AddBlueApiClient(this IServiceCollection services)
    {
        services.AddHttpClient<WeatherApiClient>(client => client.BaseAddress = new Uri("http://blue-api"));
        
        return services;
    }
}