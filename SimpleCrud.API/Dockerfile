FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SimpleCrud.API/SimpleCrud.API.csproj", "SimpleCrud.API/"]
COPY ["SimpleCrud.Infrastructure/SimpleCrud.Infrastructure.csproj", "SimpleCrud.Infrastructure/"]
COPY ["SimpleCrud.Application/SimpleCrud.Application.csproj", "SimpleCrud.Application/"]
COPY ["SimpleCrud.Entities/SimpleCrud.Domain.csproj", "SimpleCrud.Entities/"]
RUN dotnet restore "./SimpleCrud.API/SimpleCrud.API.csproj"
COPY . .
WORKDIR "/src/SimpleCrud.API"
RUN dotnet build "./SimpleCrud.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SimpleCrud.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleCrud.API.dll"]
