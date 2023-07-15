using Grpc.Core;
using GrpcGreeterService;
using System.Runtime.InteropServices;
using System.Text;

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
                var data = new Data();
                data.name = request.Name;
                data.greeting = string.Empty;
                say_hello(ref data);
                return Task.FromResult(new HelloReply
                {
                    Message = data.greeting
                });
            } 
            catch (Exception ex)
            {
                var status = new Status(StatusCode.Internal, ex.ToString());
                throw new RpcException(status);
            }

        }

        [DllImport("NativeStuff.dll")]
        [return: MarshalAs(UnmanagedType.BStr)]
        private static extern void say_hello(ref Data data);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct Data
        {
            public string name;
            public string greeting;
        }
    }
}