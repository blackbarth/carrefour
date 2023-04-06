FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Carrefour/Carrefour.csproj", "Carrefour/"]
RUN dotnet restore "Carrefour/Carrefour.csproj"
COPY . .
WORKDIR "/src/Carrefour"
RUN dotnet build "Carrefour.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Carrefour.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Carrefour.dll"]