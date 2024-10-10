FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5064
EXPOSE 80

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS build
WORKDIR /src
COPY Client.csproj Client.csproj
RUN dotnet restore Client.csproj
COPY . .
WORKDIR /src
RUN dotnet build Client.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Client.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Client.dll"]