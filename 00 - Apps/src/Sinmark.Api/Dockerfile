#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk AS build
WORKDIR /src
COPY ["Sinmark.Api/Sinmark.Api.csproj", "Sinmark.Api/"]
RUN dotnet restore "Sinmark.Api/Sinmark.Api.csproj"
COPY . .
WORKDIR "/src/Sinmark.Api"
RUN dotnet build "Sinmark.Api.csproj" -c Release -o /app/build

// TODO: Pasar test

FROM build AS publish
RUN dotnet publish "Sinmark.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sinmark.Api.dll"]