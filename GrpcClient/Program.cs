using Grpc.Net.Client;
using GrpcGreeterClient;

// Set to port of local GrpcService.
using var channel = GrpcChannel.ForAddress("https://localhost:7246");

// Set to port of running GrpcService container.
// using var channel = GrpcChannel.ForAddress("https://localhost:32768");
var client = new Greeter.GreeterClient(channel);
var reply = await client.SayHelloAsync(
                  new HelloRequest { Name = "P/Invoke" });
Console.WriteLine("Greeting: " + reply.Message);
Console.WriteLine("Press any key to exit...");
Console.ReadKey();