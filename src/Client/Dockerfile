FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
FROM ubuntu:24.02
USER $APP_UID
WORKDIR /app
EXPOSE 5064
EXPOSE 81

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Client/Client.csproj", "src/Client/"]
RUN dotnet restore "src/Client/Client.csproj"
COPY . .
WORKDIR "/src/Client"
RUN dotnet build "Client.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Client.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Client.dll", "--urls", "http://localhost:5064"]
