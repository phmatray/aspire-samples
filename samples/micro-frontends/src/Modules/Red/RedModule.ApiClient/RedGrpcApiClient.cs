namespace RedModule.ApiClient
{
    public class RedGrpcApiClient(Greeter.GreeterClient greeterClient)
    {
        public async Task<HelloReply> CallSayHelloAsync(string name)
        {
            HelloReply reply = await greeterClient.SayHelloAsync(new HelloRequest { Name = name });
            return reply;
        }
    }
}