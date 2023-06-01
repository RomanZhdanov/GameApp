# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app
    
# Copy csproj and restore as distinct layers
COPY *.sln .
COPY ./src/Application/*csproj ./src/Application/
COPY ./src/Domain/*csproj ./src/Domain/
COPY ./src/Infrastructure/*csproj ./src/Infrastructure/
COPY ./src/WebApi/*csproj ./src/WebApi/
COPY ./lib/RawgSharp/src/RawgSharp/*csproj ./lib/RawgSharp/src/RawgSharp/
RUN dotnet restore
    
# Copy everything else and build
COPY ./lib/. ./lib/
COPY ./src/Application/. ./src/Application/
COPY ./src/Domain/. ./src/Domain/
COPY ./src/Infrastructure/. ./src/Infrastructure/
COPY ./src/WebApi/. ./src/WebApi/

WORKDIR /app/src/WebApi
RUN dotnet publish -c Release -o out
    
# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/src/WebApi/out .
ENTRYPOINT ["dotnet", "GameApp.WebApi.dll"]

