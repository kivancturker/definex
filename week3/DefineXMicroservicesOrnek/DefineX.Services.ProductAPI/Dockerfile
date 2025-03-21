FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 60087

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DefineX.Services.ProductAPI/DefineX.Services.ProductAPI.csproj", "DefineX.Services.ProductAPI/"]
RUN dotnet restore "DefineX.Services.ProductAPI/DefineX.Services.ProductAPI.csproj"
COPY . .
WORKDIR "/src/DefineX.Services.ProductAPI"
RUN dotnet build "DefineX.Services.ProductAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "DefineX.Services.ProductAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DefineX.Services.ProductAPI.dll"]
