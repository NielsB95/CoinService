FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["CoinService/CoinService.csproj", "CoinService/"]
RUN dotnet restore "CoinService/CoinService.csproj"
COPY . .
WORKDIR "/src/CoinService"
RUN dotnet build "CoinService.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CoinService.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CoinService.dll"]