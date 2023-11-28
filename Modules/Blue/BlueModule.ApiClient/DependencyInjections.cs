using Microsoft.Extensions.DependencyInjection;

namespace BlueModule.ApiClient;

public static class DependencyInjections
{
    public static IServiceCollection AddBlueApiClient(this IServiceCollection services)
    {
        services.AddHttpClient<WeatherApiClient>(client => client.BaseAddress = new Uri("http://apiservice"));
        
        return services;
    }
}