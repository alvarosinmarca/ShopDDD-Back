#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Apps/src/Stock.Api/Stock.Api.csproj", "Apps/src/Stock.Api/"]
COPY ["Stock/src/Stock.Application/Stock.Application.csproj", "Stock/src/Stock.Application/"]
COPY ["Stock/src/Stock.Domain/Stock.Domain.csproj", "Stock/src/Stock.Domain/"]
COPY ["Stock/src/Stock.Infraestructure/Stock.Infrastructure.csproj", "Stock/src/Stock.Infraestructure/"]
RUN dotnet restore "Apps/src/Stock.Api/Stock.Api.csproj"
COPY . .
WORKDIR "/src/Apps/src/Stock.Api"
RUN dotnet build "Stock.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Stock.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Stock.Api.dll"]