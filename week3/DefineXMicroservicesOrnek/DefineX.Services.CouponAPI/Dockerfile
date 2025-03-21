FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 61848

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DefineX.Services.CouponAPI/DefineX.Services.CouponAPI.csproj", "DefineX.Services.CouponAPI/"]
RUN dotnet restore "DefineX.Services.CouponAPI/DefineX.Services.CouponAPI.csproj"
COPY . .
WORKDIR "/src/DefineX.Services.CouponAPI"
RUN dotnet build "DefineX.Services.CouponAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "DefineX.Services.CouponAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DefineX.Services.CouponAPI.dll"]
