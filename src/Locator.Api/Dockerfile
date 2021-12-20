#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Locator.Api/Locator.Api.csproj", "src/Locator.Api/"]
COPY ["src/Locator.Api.Infrastructure/Locator.Api.Infrastructure.csproj", "src/Locator.Api.Infrastructure/"]
COPY ["src/Locator.Api.Core/Locator.Api.Core.csproj", "src/Locator.Api.Core/"]
COPY ["src/Locator.Api.Contracts/Locator.Api.Contracts.csproj", "src/Locator.Api.Contracts/"]
COPY ["src/Locator.Api.Domain/Locator.Api.Domain.csproj", "src/Locator.Api.Domain/"]
RUN dotnet restore "src/Locator.Api/Locator.Api.csproj"
COPY . .
WORKDIR "/src/src/Locator.Api"
RUN dotnet build "Locator.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Locator.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Locator.Api.dll"]
