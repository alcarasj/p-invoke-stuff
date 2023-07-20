using Grpc.Net.Client;
using GrpcGreeterClient;

// Set to port of GrpcService container.
using var channel = GrpcChannel.ForAddress("http://localhost:8090");
var client = new Greeter.GreeterClient(channel);
var reply = await client.SayHelloAsync(new HelloRequest { Name = "P/Invoke" });
Console.WriteLine("Greeting: " + reply.Message);