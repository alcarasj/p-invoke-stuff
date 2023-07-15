using Grpc.Core;
using GrpcGreeterService;
using System.Runtime.InteropServices;

namespace GrpcService.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            try
            {
                var message = reverse($"Hello {request.Name}");
                return Task.FromResult(new HelloReply
                {
                    Message = message
                });
            } catch (Exception ex)
            {
                var status = new Status(StatusCode.Internal, ex.ToString());
                throw new RpcException(status);
            }

        }

        [DllImport("NativeStuff.dll")]
        private static extern string reverse(string str);
    }
}