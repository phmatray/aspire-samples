FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Modules/YellowModule.ApiService/YellowModule.ApiService.csproj", "Modules/YellowModule.ApiService/"]
RUN dotnet restore "Modules/YellowModule.ApiService/YellowModule.ApiService.csproj"
COPY . .
WORKDIR "/src/Modules/YellowModule.ApiService"
RUN dotnet build "YellowModule.ApiService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "YellowModule.ApiService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YellowModule.ApiService.dll"]
