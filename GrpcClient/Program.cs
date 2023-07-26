using Grpc.Net.Client;
using GrpcGreeterClient;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            throw new Exception("Please enter the localhost port where GrpcService is running.");
        }

        // Set to port of GrpcService container.
        using var channel = GrpcChannel.ForAddress($"http://localhost:{args[0]}");
        var client = new Greeter.GreeterClient(channel);
        var reply = client.SayHello(new HelloRequest { Name = "P/Invoke" });
        Console.WriteLine("Greeting: " + reply.Message);
    }
}