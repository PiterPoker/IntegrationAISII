#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
#EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["IntegrationAISII.API/IntegrationAISII.API.csproj", "IntegrationAISII.API/"]
COPY ["IntegrationAISII.Infrastructure/IntegrationAISII.Infrastructure.csproj", "IntegrationAISII.Infrastructure/"]
COPY ["IntegrationAISII.Domain/IntegrationAISII.Domain.csproj", "IntegrationAISII.Domain/"]
RUN dotnet restore "./IntegrationAISII.API/IntegrationAISII.API.csproj"
COPY ["StatusAISII/StatusAISII.csproj", "StatusAISII/"]
COPY . .
WORKDIR "/src/IntegrationAISII.API"
RUN dotnet build "./IntegrationAISII.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./IntegrationAISII.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IntegrationAISII.API.dll"]