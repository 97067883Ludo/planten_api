FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["planten_api/planten_api.csproj", "planten_api/"]
RUN dotnet restore "planten_api/planten_api.csproj"
COPY . .
WORKDIR "/src/planten_api"
RUN dotnet build "planten_api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "planten_api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "planten api.dll"]
