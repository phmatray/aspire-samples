namespace Web.Bff.Gateway.Extensions
{
    internal static class Extensions
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {
            builder.Services.AddHealthChecks()
                .AddUrlGroup(new Uri("http://blue-api/health"), "blueapi-check")
                .AddUrlGroup(new Uri("http://green-api/health"), "greenapi-check")
                .AddUrlGroup(new Uri("http://red-api/health"), "redapi-check")
                .AddUrlGroup(new Uri("http://yellow-api/health"), "yellowapi-check");
        }
    }
}