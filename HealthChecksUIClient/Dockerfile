#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["HealthChecksUIClient/HealthChecksUIClient.csproj", "HealthChecksUIClient/"]
RUN dotnet restore "HealthChecksUIClient/HealthChecksUIClient.csproj"
COPY . .
WORKDIR "/src/HealthChecksUIClient"
RUN dotnet build "HealthChecksUIClient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HealthChecksUIClient.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HealthChecksUIClient.dll"]