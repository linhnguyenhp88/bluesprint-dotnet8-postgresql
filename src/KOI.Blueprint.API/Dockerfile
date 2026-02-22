# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/KOI.Blueprint.API/KOI.Blueprint.API.csproj", "src/KOI.Blueprint.API/"]
COPY ["src/KOI.Blueprint.Application/KOI.Blueprint.Application.csproj", "src/KOI.Blueprint.Application/"]
COPY ["src/KOI.Blueprint.Infrastructure/KOI.Blueprint.Infrastructure.csproj", "src/KOI.Blueprint.Infrastructure/"]
COPY ["src/KOI.Blueprint.Domain/KOI.Blueprint.Domain.csproj", "src/KOI.Blueprint.Domain/"]
COPY ["src/KOI.Blueprint.Shared/KOI.Blueprint.Shared.csproj", "src/KOI.Blueprint.Shared/"]
RUN dotnet restore "./src/KOI.Blueprint.API/KOI.Blueprint.API.csproj"
COPY . .
WORKDIR "/src/src/KOI.Blueprint.API"
RUN dotnet build "./KOI.Blueprint.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./KOI.Blueprint.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KOI.Blueprint.API.dll"]