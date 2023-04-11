FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["planten api/planten api.csproj", "planten api/"]
RUN dotnet restore "planten api/planten api.csproj"
COPY . .
WORKDIR "/src/planten api"
RUN dotnet build "planten api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "planten api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "planten api.dll"]
