#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/OrbitaChallengeApi.Application/OrbitaChallengeApi.Application.csproj", "src/OrbitaChallengeApi.Application/"]
RUN dotnet restore "src/OrbitaChallengeApi.Application/OrbitaChallengeApi.Application.csproj"
COPY . .
WORKDIR "/src/src/OrbitaChallengeApi.Application"
RUN dotnet build "OrbitaChallengeApi.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrbitaChallengeApi.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrbitaChallengeApi.Application.dll"]