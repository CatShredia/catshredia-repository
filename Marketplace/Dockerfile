# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["src/Marketplace.Api/Marketplace.Api.csproj", "Marketplace.Api/"]
COPY ["src/Marketplace.Core/Marketplace.Core.csproj", "Marketplace.Core/"]
COPY ["src/Marketplace.Infrastructure/Marketplace.Infrastructure.csproj", "Marketplace.Infrastructure/"]
RUN dotnet restore "Marketplace.Api/Marketplace.Api.csproj"
COPY . .
WORKDIR "src/Marketplace.Api"
RUN dotnet build "Marketplace.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Marketplace.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Marketplace.Api.dll"]