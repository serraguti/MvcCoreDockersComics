FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY *.csproj ./
RUN dotnet restore 
COPY . .
WORKDIR "/src/MvcCoreDockersComics"
RUN dotnet build "/src/MvcCoreDockersComics.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "/src/MvcCoreDockersComics.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MvcCoreDockersComics.dll"]