using System.Net.Sockets;
using System.Text.Json;
using Aspire.Hosting.ApplicationModel;

// ReSharper disable once CheckNamespace
namespace Aspire.Hosting;

/// <summary>
/// Provides extension methods for adding Plex resources to an <see cref="IDistributedApplicationBuilder"/>.
/// </summary>
public static class PlexBuilderExtensions
{
    private const string TimeZoneEnvVarName = "TZ";
    private const string VersionEnvVarName = "VERSION";
    
    /// <summary>
    /// Adds a Plex container to the application model. The default image is "ghcr.io/linuxserver/plex" and the tag is "latest".
    /// </summary>
    /// <param name="builder">The <see cref="IDistributedApplicationBuilder"/>.</param>
    /// <param name="name">The name of the resource. This name will be used as the connection string name when referenced in a dependency.</param>
    /// <param name="port">The host port for Plex.</param>
    /// <param name="timeZone">The time zone for the Plex container. Defaults to "America/New_York".</param>
    /// <returns>A reference to the <see cref="IResourceBuilder{PlexContainerResource}"/>.</returns>
    public static IResourceBuilder<PlexContainerResource> AddPlexContainer(
        this IDistributedApplicationBuilder builder,
        string name,
        int? port = null,
        string? timeZone = null)
    {
        var plexContainer = new PlexContainerResource(name);
        
        return builder
            .AddResource(plexContainer)
            .WithAnnotation(new ContainerImageAnnotation { Image = "ghcr.io/linuxserver/plex", Tag = "latest" })
            .WithAnnotation(new ServiceBindingAnnotation(
                protocol: ProtocolType.Tcp,
                uriScheme: "http",
                name: "web",
                port: port,
                containerPort: 32400))
            .WithAnnotation(new ManifestPublishingCallbackAnnotation(WritePlexContainerToManifest))
            .WithEnvironment(TimeZoneEnvVarName, timeZone ?? "America/New_York")
            .WithEnvironment(VersionEnvVarName, "docker");
    }
    
    private static void WritePlexContainerToManifest(Utf8JsonWriter json)
    {
        json.WriteString("type", "plex.server.v0");
    }
}