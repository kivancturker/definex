FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 43432

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DefineX.Services.Identity/DefineX.Services.Identity.csproj", "DefineX.Services.Identity/"]
RUN dotnet restore "DefineX.Services.Identity/DefineX.Services.Identity.csproj"
COPY . .
WORKDIR "/src/DefineX.Services.Identity"
RUN dotnet build "DefineX.Services.Identity.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "DefineX.Services.Identity.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DefineX.Services.Identity.dll"]
