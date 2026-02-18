// ReSharper disable once CheckNamespace
namespace Aspire.Hosting;

/// <summary>
/// A resource that represents a FileBrowser container.
/// </summary>
/// <param name="name">The name of the resource.</param>
public class FileBrowserContainerResource(string name)
    : ContainerResource(name), IResourceWithConnectionString
{
    /// <summary>
    /// Gets the connection string for the FileBrowser server.
    /// </summary>
    /// <returns>A connection string for the FileBrowser server in the form "http://host:port".</returns>
    public string? GetConnectionString()
    {
        if (!this.TryGetAllocatedEndPoints(out var allocatedEndpoints))
        {
            throw new DistributedApplicationException($"FileBrowser resource \"{Name}\" does not have endpoint annotation.");
        }

        var endpoint = allocatedEndpoints.Single();
        return $"http://{endpoint.EndPointString}";
    }
}