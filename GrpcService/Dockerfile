FROM mcr.microsoft.com/dotnet/sdk:6.0 as builder
WORKDIR /src
COPY ./GrpcService ./GrpcService
RUN dotnet publish "GrpcService/GrpcService.csproj" -c Release -o /app /p:UseAppHost=false
COPY ../NativeStuff/x64/Release /app

FROM mcr.microsoft.com/dotnet/aspnet:6.0
EXPOSE 7001
ENV ASPNETCORE_URLS=http://+:7001
WORKDIR /app
COPY --from=builder /app /app
WORKDIR /
ENTRYPOINT ["dotnet", "/app/GrpcService.dll"]