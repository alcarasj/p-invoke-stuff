$CurrentDirectory = Get-Location

Import-Module "C:\Program Files\Microsoft Visual Studio\2022\Enterprise\Common7\Tools\Microsoft.VisualStudio.DevShell.dll"
Enter-VsDevShell 9a18b797
Set-Location $CurrentDirectory
msbuild ./NativeStuff/NativeStuff.vcxproj /property:Configuration=Release /property:Platform=x64

docker build -t "p-invoke-stuff:latest" -f ./GrpcService/Dockerfile .