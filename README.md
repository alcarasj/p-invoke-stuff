# p-invoke-stuff
This is a ASP.NET gRPC service calling into native C++ code via [P/Invoke](https://learn.microsoft.com/en-us/dotnet/standard/native-interop/pinvoke). 

## Run on Docker
Requires a Ubuntu/macOS machine with Docker installed.
1. Open a terminal window and `cd` to repo root.
2. `make e2e` (if on x64) or `make e2e-arm64` (if on ARM64)