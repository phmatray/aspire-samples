using ServiceReference;

namespace GreenModule.ApiClient;

public class GreenWcfApiClient
{
    // http://localhost:5032
    // http://green-api
    private readonly ServiceClient _client = new(
        ServiceClient.EndpointConfiguration.BasicHttpBinding_IService,
        "http://localhost:5032/Service.svc");

    public async Task<string> GetDataAsync(int value)
        => await _client.GetDataAsync(value);

    public async Task<CompositeType> GetDataUsingDataContractAsync(CompositeType composite)
        => await _client.GetDataUsingDataContractAsync(composite);
}