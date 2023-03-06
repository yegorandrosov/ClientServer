FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Androsov.Web/Androsov.Web.csproj", "Androsov.Web/"]
RUN dotnet restore "Androsov.Web/Androsov.Web.csproj"
COPY . .
WORKDIR "/src/Androsov.Web"
RUN dotnet build "Androsov.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Androsov.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Androsov.Web.dll"]