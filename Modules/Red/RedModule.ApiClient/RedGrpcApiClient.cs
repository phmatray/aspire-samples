using System.Threading.Channels;
using Grpc.Core;
using Grpc.Net.Client;

namespace RedModule.ApiClient;

public class RedGrpcApiClient
{
    public async Task<HelloReply> CallSayHelloAsync(string name)
    {
        using var channel = GrpcChannel.ForAddress("http://localhost:5233");
        var client = new Greeter.GreeterClient(channel);
        var reply = await client.SayHelloAsync(new HelloRequest { Name = name });
        return reply;
    }
}