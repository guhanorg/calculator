# Calculator Microservices

A simple calculator built as microservices with .NET 9 and Blazor WebAssembly.

## Architecture

| Service | Tech | Default port |
|---|---|---|
| `CalculatorApi` | ASP.NET Core 9 Web API | 5000 |
| `CalculatorUI` | Blazor WebAssembly (served via nginx) | 3000 |
| `CalculatorApi.Tests` | xUnit | — |

## Run locally

```bash
# Option 1 — Docker Compose (recommended)
docker compose up --build

# Option 2 — separate terminals
dotnet run --project src/CalculatorApi
dotnet run --project src/CalculatorUI
```

Open http://localhost:3000 in your browser.

## Run tests

```bash
dotnet test
```

## Upgrade to .NET 10

1. Install the .NET 10 SDK.
2. Change `<TargetFramework>net9.0</TargetFramework>` → `net10.0` in all three `.csproj` files.
3. Update the `FROM` lines in both Dockerfiles to use the `10.0` tags.
