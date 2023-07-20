# p-invoke-stuff
This is a ASP.NET gRPC service calling into native C++ code via [P/Invoke](https://learn.microsoft.com/en-us/dotnet/standard/native-interop/pinvoke). 
Remaining items to-do as of 20 Jul 2023:

- The gRPC service running on Docker cannot find the native DLL, even though they are in the same directory in the container.