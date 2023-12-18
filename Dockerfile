# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Use the SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["EphemeralEnvironments.API/EphemeralEnvironments.API.csproj", "EphemeralEnvironments.API/"]
RUN dotnet restore "./EphemeralEnvironments.API/EphemeralEnvironments.API.csproj"

# Copy the entire solution and build the application
COPY . .
WORKDIR "/src/EphemeralEnvironments.API"
RUN dotnet build "./EphemeralEnvironments.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the application
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EphemeralEnvironments.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Use the ASP.NET image for the runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app

# Copy the published files from the 'publish' stage
COPY --from=publish /app/publish .

# Set the entry point for the container
ENTRYPOINT ["dotnet", "EphemeralEnvironments.API.dll"]
