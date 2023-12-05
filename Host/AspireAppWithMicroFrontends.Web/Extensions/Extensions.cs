using BlueModule.ApiClient;
using GreenModule.ApiClient;
using RedModule.ApiClient;
using RedModule.ApiClient.Extensions;
using YellowModule.ApiClient;

namespace AspireAppWithMicroFrontends.Web.Extensions;

public static class Extensions
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;
        
        // Add Module API Clients
        services.AddBlueApiClient();
        services.AddGreenApiClient();
        services.AddRedApiClient();
        services.AddYellowApiClient();
    }
}