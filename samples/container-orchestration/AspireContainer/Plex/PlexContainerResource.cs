// ReSharper disable once CheckNamespace
namespace Aspire.Hosting;

/// <summary>
/// A resource that represents a Plex container.
/// </summary>
/// <param name="name">The name of the resource.</param>
public class PlexContainerResource(string name)
    : ContainerResource(name), IPlexResource
{
    /// <summary>
    /// Gets the connection string for the Plex server.
    /// </summary>
    /// <returns>A connection string for the Plex server in the form "http://host:port".</returns>
    public string? GetConnectionString()
    {
        if (!this.TryGetAllocatedEndPoints(out var allocatedEndpoints))
        {
            throw new DistributedApplicationException($"Plex resource \"{Name}\" does not have endpoint annotation.");
        }
        
        var endpoint = allocatedEndpoints.Single();
        return $"http://{endpoint.EndPointString}";
    }
}