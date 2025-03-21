FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 25982

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DefineX.Services.ShoppingCartAPI/DefineX.Services.ShoppingCartAPI.csproj", "DefineX.Services.ShoppingCartAPI/"]
COPY ["DefineX.MessageBus/DefineX.MessageBus.csproj", "DefineX.MessageBus/"]
RUN dotnet restore "DefineX.Services.ShoppingCartAPI/DefineX.Services.ShoppingCartAPI.csproj"
COPY . .
WORKDIR "/src/DefineX.Services.ShoppingCartAPI"
RUN dotnet build "DefineX.Services.ShoppingCartAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "DefineX.Services.ShoppingCartAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DefineX.Services.ShoppingCartAPI.dll"]
