using BlueModule.ApiClient;
using BlueModule.ApiClient.Extensions;
using GreenModule.ApiClient;
using GreenModule.ApiClient.Extensions;
using RedModule.ApiClient;
using RedModule.ApiClient.Extensions;
using YellowModule.ApiClient;
using YellowModule.ApiClient.Extensions;

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