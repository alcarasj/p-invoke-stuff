using Grpc.Core;
using GrpcGreeterService;
using System.Buffers;
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
        private class NativeMethods
        {
            [DllImport("NativeStuff.dll", CallingConvention = CallingConvention.Cdecl)]
            [return: MarshalAs(UnmanagedType.BStr)]
            internal static extern string say_hello([MarshalAs(UnmanagedType.BStr)] string name);
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            try
            {
                var name = request.Name;
                var greeting = NativeMethods.say_hello(name);
                return Task.FromResult(new HelloReply
                {
                    Message = greeting
                });
            } 
            catch (Exception ex)
            {
                var status = new Status(StatusCode.Internal, ex.ToString());
                throw new RpcException(status);
            }

        }
    }
}