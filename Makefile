e2e:
	make server
	make client

client:
	dotnet run --project ./GrpcClient/GrpcClient.csproj -- 8090

server:
	docker build -t "p-invoke-stuff:latest" -f ./GrpcService/Dockerfile.AMD64 .
	docker stop p-invoke-stuff
	docker run --name p-invoke-stuff -p 8090:7001 --rm -d p-invoke-stuff:latest	

e2e-arm64:
	make server-arm64
	make client

server-arm64:
	docker build -t "p-invoke-stuff:latest" -f ./GrpcService/Dockerfile.ARM64 .
	docker run --name p-invoke-stuff -p 8090:7001 --rm -d p-invoke-stuff:latest	