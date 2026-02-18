using System.Net.Sockets;
using System.Text.Json;
using Aspire.Hosting.ApplicationModel;

// ReSharper disable once CheckNamespace
namespace Aspire.Hosting;

/// <summary>
/// Provides extension methods for adding Flame resources to an <see cref="IDistributedApplicationBuilder"/>.
/// </summary>
public static class FlameBuilderExtensions
{
    private const string PasswordEnvVarName = "PASSWORD";

    /// <summary>
    /// Adds a Flame container to the application model. The default image is "pawelmalak/flame" and the tag is "latest".
    /// </summary>
    /// <param name="builder">The <see cref="IDistributedApplicationBuilder"/>.</param>
    /// <param name="name">The name of the resource. This name will be used as the connection string name when referenced in a dependency.</param>
    /// <param name="port">The host port for Flame.</param>
    /// <param name="password">The password for the Flame container.</param>
    /// <returns>A reference to the <see cref="IResourceBuilder{FlameContainerResource}"/>.</returns>
    public static IResourceBuilder<FlameContainerResource> AddFlameContainer(
        this IDistributedApplicationBuilder builder,
        string name,
        int? port = null,
        string? password = null)
    {
        var flameContainer = new FlameContainerResource(name);

        return builder
            .AddResource(flameContainer)
            .WithAnnotation(new ContainerImageAnnotation { Image = "pawelmalak/flame", Tag = "latest" })
            .WithAnnotation(new ServiceBindingAnnotation(
                protocol: ProtocolType.Tcp,
                uriScheme: "http",
                name: "web",
                port: port,
                containerPort: 5005))
            .WithAnnotation(new ManifestPublishingCallbackAnnotation(WriteFlameContainerToManifest))
            .WithEnvironment(PasswordEnvVarName, password ?? "defaultpassword");
    }

    private static void WriteFlameContainerToManifest(Utf8JsonWriter json)
    {
        json.WriteString("type", "flame.server.v0");
    }
}