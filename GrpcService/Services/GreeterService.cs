using Grpc.Core;
using GrpcGreeterService;
using System;
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
            [DllImport("NativeStuff.dll")]
            internal static extern IntPtr say_hello([MarshalAs(UnmanagedType.LPStr)] string name);
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            try
            {
                var name = request.Name;
                var greetingIntPointer = NativeMethods.say_hello(name);
                var greeting = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(greetingIntPointer);

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