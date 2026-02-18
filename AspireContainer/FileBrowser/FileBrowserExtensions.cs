using System.Net.Sockets;
using System.Text.Json;
using Aspire.Hosting.ApplicationModel;

// ReSharper disable once CheckNamespace
namespace Aspire.Hosting;

/// <summary>
/// Provides extension methods for adding FileBrowser resources to an <see cref="IDistributedApplicationBuilder"/>.
/// </summary>
public static class FileBrowserExtensions
{
    /// <summary>
    /// Adds a FileBrowser container to the application model. The default image is "filebrowser/filebrowser" and the tag is "latest".
    /// </summary>
    /// <param name="builder">The <see cref="IDistributedApplicationBuilder"/>.</param>
    /// <param name="name">The name of the resource. This name will be used as the connection string name when referenced in a dependency.</param>
    /// <param name="port">The host port for FileBrowser.</param>
    /// <returns>A reference to the <see cref="IResourceBuilder{FileBrowserContainerResource}"/>.</returns>
    public static IResourceBuilder<FileBrowserContainerResource> AddFileBrowserContainer(
        this IDistributedApplicationBuilder builder,
        string name,
        int? port = null)
    {
        var fileBrowserContainer = new FileBrowserContainerResource(name);

        return builder
            .AddResource(fileBrowserContainer)
            .WithAnnotation(new ContainerImageAnnotation { Image = "filebrowser/filebrowser", Tag = "latest" })
            .WithAnnotation(new ServiceBindingAnnotation(
                protocol: ProtocolType.Tcp,
                uriScheme: "http",
                name: "web",
                port: port,
                containerPort: 80))
            .WithAnnotation(new ManifestPublishingCallbackAnnotation(WriteFileBrowserContainerToManifest));
    }

    private static void WriteFileBrowserContainerToManifest(Utf8JsonWriter json)
    {
        json.WriteString("type", "filebrowser.server.v0");
    }
}