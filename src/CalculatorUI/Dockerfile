FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["src/CalculatorUI/CalculatorUI.csproj", "src/CalculatorUI/"]
RUN dotnet restore "src/CalculatorUI/CalculatorUI.csproj"
COPY . .
WORKDIR "/src/src/CalculatorUI"
RUN dotnet publish "CalculatorUI.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=build /app/publish/wwwroot .
COPY src/CalculatorUI/nginx.conf /etc/nginx/nginx.conf
