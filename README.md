# p-invoke-stuff
This is a ASP.NET gRPC service calling into native C++ code via [P/Invoke](https://learn.microsoft.com/en-us/dotnet/standard/native-interop/pinvoke). 
Remaining items to-do as of 20 Jul 2023:

- The gRPC service running on Docker cannot find the native DLL, even though they are in the same directory in the container.

## Run using Docker
Requires .NET 6, Visual Studio 2022 and Docker to be installed.
1. Open PS window and `cd` to repo root.
2. Build the Docker image with `.\BuildDockerImage.ps1`
3. Run the container with `docker run --name p-invoke-stuff -p 8090:7001 --rm -d p-invoke-stuff:latest`
4. Make a request using the client with `dotnet run --project .\GrpcClient\GrpcClient.csproj`