#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["StatusAISII/StatusAISII.csproj", "StatusAISII/"]
COPY ["IntegrationAISII.API/IntegrationAISII.API.csproj", "IntegrationAISII.API/"]
COPY ["IntegrationAISII.Infrastructure/IntegrationAISII.Infrastructure.csproj", "IntegrationAISII.Infrastructure/"]
COPY ["IntegrationAISII.Domain/IntegrationAISII.Domain.csproj", "IntegrationAISII.Domain/"]
RUN dotnet restore "./StatusAISII/StatusAISII.csproj"
COPY . .
WORKDIR "/src/StatusAISII"
RUN dotnet build "./StatusAISII.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./StatusAISII.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StatusAISII.dll"]