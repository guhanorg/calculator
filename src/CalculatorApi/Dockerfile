FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["src/CalculatorApi/CalculatorApi.csproj", "src/CalculatorApi/"]
RUN dotnet restore "src/CalculatorApi/CalculatorApi.csproj"
COPY . .
WORKDIR "/src/src/CalculatorApi"
RUN dotnet build "CalculatorApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CalculatorApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CalculatorApi.dll"]
