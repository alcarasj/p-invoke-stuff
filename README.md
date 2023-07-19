# p-invoke-stuff
This is a ASP.NET gRPC service calling into native C++ code via [P/Invoke](https://learn.microsoft.com/en-us/dotnet/standard/native-interop/pinvoke). 
Remaining items to-do as of 19 Jul 2023:

- Find out a way to build the NativeStuff.vcxproj and package the output DLL with the `GrpcService` Docker image.