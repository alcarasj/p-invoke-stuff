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

        var targetPort = args[0];
        Console.WriteLine("Saying hello to the GrpcService at port " + targetPort + "...");
        using var channel = GrpcChannel.ForAddress($"http://localhost:{args[0]}");
        var client = new Greeter.GreeterClient(channel);
        var reply = client.SayHello(new HelloRequest { Name = "P/Invoke" });
        Console.WriteLine("Hooray! Greeting received from GrpcService: " + reply.Message);
    }
}