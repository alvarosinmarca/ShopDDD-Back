#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Apps/src/Stock.Api/Stock.Api.csproj", "Apps/src/Stock.Api/"]
COPY ["../../../../GitHub/SharedKernel/src/Infrastructure/SharedKernel.Infrastructure.csproj", "../../../../GitHub/SharedKernel/src/Infrastructure/"]
COPY ["../../../../GitHub/SharedKernel/src/Application/SharedKernel.Application.csproj", "../../../../GitHub/SharedKernel/src/Application/"]
COPY ["../../../../GitHub/SharedKernel/src/Domain/SharedKernel.Domain.csproj", "../../../../GitHub/SharedKernel/src/Domain/"]
COPY ["Stock/src/Stock.Application/Stock.Application.csproj", "Stock/src/Stock.Application/"]
COPY ["Stock/src/Stock.Domain/Stock.Domain.csproj", "Stock/src/Stock.Domain/"]
COPY ["Stock/src/Stock.Infraestructure/Stock.Infrastructure.csproj", "Stock/src/Stock.Infraestructure/"]
COPY ["../../../../GitHub/SharedKernel/src/Api/SharedKernel.Api.csproj", "../../../../GitHub/SharedKernel/src/Api/"]
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