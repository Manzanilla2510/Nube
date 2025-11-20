# fase build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["prueba2.csproj", "./"]
RUN dotnet restore "./prueba2.csproj"
COPY . .
RUN dotnet build "./prueba2.csproj" -c $BUILD_CONFIGURATION -o /app/build

# fase publish
FROM build AS publish
RUN dotnet publish "./prueba2.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# fase final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "prueba2.dll"]
