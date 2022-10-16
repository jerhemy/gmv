FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["GMV/GMV.csproj", "GMV/"]
RUN dotnet restore "GMV/GMV.csproj"
COPY . .
WORKDIR "/src/GMV"
RUN dotnet build "GMV.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GMV.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GMV.dll"]
