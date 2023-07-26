$CurrentDirectory = Get-Location

rm ./GrpcService/bin -r -force
rm ./GrpcService/obj -r -force
rm ./NativeStuff/x64 -r -force

# Build NativeStuff C++ code into DLL using MSBuild.
Import-Module "C:\Program Files\Microsoft Visual Studio\2022\Enterprise\Common7\Tools\Microsoft.VisualStudio.DevShell.dll"
Enter-VsDevShell -VsInstallPath "C:\Program Files\Microsoft Visual Studio\2022\Enterprise"
Set-Location $CurrentDirectory
msbuild ./NativeStuff/NativeStuff.vcxproj /property:Configuration=Release /property:Platform=x64

# Publish GrpcService ASP.NET application.
dotnet publish "GrpcService/GrpcService.csproj" -c Release -o /app /p:UseAppHost=false

Copy-Item -Path "./NativeStuff/x64/Release/NativeStuff.dll" -Destination "./GrpcService/bin/Release/net6.0"

# Run the GrpcService ASP.NET application.
start powershell {dotnet "./GrpcService/bin/Release/net6.0/GrpcService.dll"}

# Run the client to verify the service is working.
dotnet run --project .\GrpcClient\GrpcClient.csproj -- 7001