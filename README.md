# p-invoke-stuff
This is a ASP.NET gRPC service calling into native C++ code via [P/Invoke](https://learn.microsoft.com/en-us/dotnet/standard/native-interop/pinvoke). 
Remaining items to-do as of 15 Jul 2023:

- Find out a way to build the NativeStuff.vcxproj and package the output DLL with the `GrpcService` Docker image.
- Find out why `GrpcService` occasionally exits with code 3221226356 (0xC0000374) after 3 or 4 invocations - apparently this code is due to heap corruption.
