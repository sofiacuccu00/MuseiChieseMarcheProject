FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MuseiChieseMarche/MuseiChieseMarche.csproj", "MuseiChieseMarche/"] 
COPY ["MuseiChiese.Modelli/MuseiChiese.Modelli.csproj", "MuseiChiese.Modelli/"]
RUN dotnet restore "./MuseiChieseMarche/MuseiChieseMarche.csproj"
COPY . .
WORKDIR "/src/MuseiChieseMarche"
RUN dotnet build "./MuseiChieseMarche.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Questa fase viene usata per pubblicare il progetto di servizio da copiare nella fase finale
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MuseiChieseMarche.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MuseiChieseMarche.dll"]


