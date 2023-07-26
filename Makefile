e2e:
	make server
	make client

client:
	dotnet run --project ./GrpcClient/GrpcClient.csproj -- 8090

server:
	docker build -t "p-invoke-stuff:latest" -f ./GrpcService/Dockerfile .
	docker run --name p-invoke-stuff -p 8090:7001 --rm -d p-invoke-stuff:latest	
