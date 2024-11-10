#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TM_TodoManager.Api/TM_TodoManager.Api.csproj", "TM_TodoManager.Api/"]
COPY ["TM_TodoManager.Application/TM_TodoManager.Application.csproj", "TM_TodoManager.Application/"]
COPY ["TM_TodoManager.Core/TM_TodoManager.Core.csproj", "TM_TodoManager.Core/"]
COPY ["TM_TodoManager.Infrastructure/TM_TodoManager.Infrastructure.csproj", "TM_TodoManager.Infrastructure/"]
COPY ["TM_TodoManager.Shared/TM_TodoManager.Shared.csproj", "TM_TodoManager.Shared/"]
RUN dotnet restore "./TM_TodoManager.Api/TM_TodoManager.Api.csproj"
COPY . .
WORKDIR "/src/TM_TodoManager.Api"
RUN dotnet build "./TM_TodoManager.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TM_TodoManager.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TM_TodoManager.Api.dll"]