// ReSharper disable once CheckNamespace
namespace Aspire.Hosting;

/// <summary>
/// A resource that represents a Flame container.
/// </summary>
/// <param name="name">The name of the resource.</param>
public class FlameContainerResource(string name)
    : ContainerResource(name), IFlameResource
{
    /// <summary>
    /// Gets the connection string for the Flame server.
    /// </summary>
    /// <returns>A connection string for the Flame server in the form "http://host:port".</returns>
    public string? GetConnectionString()
    {
        if (!this.TryGetAllocatedEndPoints(out var allocatedEndpoints))
        {
            throw new DistributedApplicationException($"Flame resource \"{Name}\" does not have endpoint annotation.");
        }

        var endpoint = allocatedEndpoints.Single();
        return $"http://{endpoint.EndPointString}";
    }
}