![AspireAppWithMicroFrontends banner](.github/banner.png)

# AspireAppWithMicroFrontends

<!-- portfolio-badges:start -->
<!-- Identity -->
[![phmatray - AspireAppWithMicroFrontends](https://img.shields.io/static/v1?label=phmatray&message=AspireAppWithMicroFrontends&color=blue&logo=github)](https://github.com/phmatray/AspireAppWithMicroFrontends)
![Top language](https://img.shields.io/github/languages/top/phmatray/AspireAppWithMicroFrontends)
[![Stars](https://img.shields.io/github/stars/phmatray/AspireAppWithMicroFrontends?style=social)](https://github.com/phmatray/AspireAppWithMicroFrontends/stargazers)
[![Forks](https://img.shields.io/github/forks/phmatray/AspireAppWithMicroFrontends?style=social)](https://github.com/phmatray/AspireAppWithMicroFrontends/network/members)
[![License](https://img.shields.io/github/license/phmatray/AspireAppWithMicroFrontends)](https://github.com/phmatray/AspireAppWithMicroFrontends/blob/HEAD/LICENSE)

<!-- Activity -->
[![Issues](https://img.shields.io/github/issues/phmatray/AspireAppWithMicroFrontends)](https://github.com/phmatray/AspireAppWithMicroFrontends/issues)
[![Pull requests](https://img.shields.io/github/issues-pr/phmatray/AspireAppWithMicroFrontends)](https://github.com/phmatray/AspireAppWithMicroFrontends/pulls)
[![Last commit](https://img.shields.io/github/last-commit/phmatray/AspireAppWithMicroFrontends)](https://github.com/phmatray/AspireAppWithMicroFrontends/commits)
<!-- portfolio-badges:end -->


A demonstration project showcasing **micro-frontends architecture** built with **.NET Aspire** and **Blazor**. The application orchestrates multiple independent UI modules (Blue, Green, Red, Yellow) — each with its own API service, domain layer, and web components — composed into several shell applications using different rendering strategies.

## Architecture Overview

The solution follows a modular monorepo approach where each feature module is fully self-contained with its own domain, API service, API client, and Blazor web components. A .NET Aspire AppHost orchestrates all services and frontends, providing service discovery, health checks, and a unified developer dashboard.

```
┌─────────────────────────────────────────────────────────┐
│                  .NET Aspire AppHost                     │
│            (orchestration & service discovery)           │
├─────────────────────────────────────────────────────────┤
│                                                         │
│  Shells (Frontends)          BFF Layer                  │
│  ┌──────────────────┐       ┌─────────────────────┐    │
│  │ Web (SSR Blazor)  │       │ Web.Bff.Gateway     │    │
│  │ WasmShell (WASM)  │       │ (YARP Reverse Proxy)│    │
│  │ HtmxAppServer     │       └─────────────────────┘    │
│  └──────────────────┘                                   │
│                                                         │
│  Modules (Micro-Frontends)                              │
│  ┌────────┐ ┌────────┐ ┌────────┐ ┌────────┐          │
│  │  Blue  │ │ Green  │ │  Red   │ │ Yellow │          │
│  │ ┌────┐ │ │ ┌────┐ │ │ ┌────┐ │ │ ┌────┐ │          │
│  │ │ Web│ │ │ │ Web│ │ │ │ Web│ │ │ │ Web│ │          │
│  │ │ API│ │ │ │ API│ │ │ │ API│ │ │ │ API│ │          │
│  │ │Dom.│ │ │ │Dom.│ │ │ │Dom.│ │ │ │Dom.│ │          │
│  │ │Clt.│ │ │ │Clt.│ │ │ │Clt.│ │ │ │Clt.│ │          │
│  │ └────┘ │ │ └────┘ │ │ └────┘ │ │ └────┘ │          │
│  └────────┘ └────────┘ └────────┘ └────────┘          │
└─────────────────────────────────────────────────────────┘
```

## Key Technologies

- **.NET 8** with [.NET Aspire](https://learn.microsoft.com/en-us/dotnet/aspire/) for cloud-native orchestration
- **Blazor** (Server-Side Rendering + WebAssembly) for interactive UI
- **HTMX** as an alternative lightweight frontend approach
- **YARP** (Yet Another Reverse Proxy) for the BFF gateway
- **MudBlazor** component library for Material Design UI
- **Entity Framework Core** with SQLite (WasmShell)
- **ASP.NET Core Identity** for authentication (WasmShell)

## Project Structure

```
AspireAppWithMicroFrontends/
├── src/
│   ├── Host/
│   │   ├── AspireAppWithMicroFrontends.AppHost/   # Aspire orchestrator (entry point)
│   │   ├── AspireAppWithMicroFrontends.ServiceDefaults/  # Shared service configuration
│   │   └── AspireAppWithMicroFrontends.Web/       # SSR Blazor shell (MudBlazor)
│   │
│   ├── Modules/                                   # Micro-frontend modules
│   │   ├── Blue/
│   │   │   ├── BlueModule.ApiService/             # HTTP API service
│   │   │   ├── BlueModule.ApiClient/              # Typed HTTP client
│   │   │   ├── BlueModule.Domain/                 # Domain models & logic
│   │   │   └── BlueModule.Web/                    # Blazor UI components
│   │   ├── Green/                                 # (same structure)
│   │   ├── Red/                                   # (same structure)
│   │   └── Yellow/                                # (same structure)
│   │
│   ├── WasmShell/                                 # Blazor WebAssembly shell
│   │   ├── WasmShell/                             # Server host (Identity, EF Core)
│   │   └── WasmShell.Client/                      # WASM client project
│   │
│   ├── WebShell/                                  # Additional Blazor shell variant
│   │   ├── WebShell/
│   │   └── WebShell.Client/
│   │
│   ├── HtmxAppServer/                            # HTMX-based frontend (Dockerized)
│   │
│   └── Web.Bff.Gateway/                          # YARP-based BFF reverse proxy
│
├── filters/                                       # Solution filters (.slnf)
├── docs/                                          # Writerside documentation
├── Directory.Build.props                          # Shared build properties & analyzers
├── global.json                                    # .NET SDK version pinning
└── AspireAppWithMicroFrontends.sln
```

## Services

| Service | Project | Description |
|---------|---------|-------------|
| **AppHost** | `AspireAppWithMicroFrontends.AppHost` | Aspire orchestrator — starts and wires all services |
| **Web Frontend** | `AspireAppWithMicroFrontends.Web` | Server-side Blazor shell with MudBlazor |
| **WasmShell** | `WasmShell` | Blazor WebAssembly shell with Identity & SQLite |
| **HtmxAppServer** | `HtmxAppServer` | HTMX-based server-rendered frontend |
| **BFF Gateway** | `Web.Bff.Gateway` | YARP reverse proxy aggregating module APIs |
| **Blue API** | `BlueModule.ApiService` | API service for the Blue module |
| **Green API** | `GreenModule.ApiService` | API service for the Green module |
| **Red API** | `RedModule.ApiService` | API service for the Red module |
| **Yellow API** | `YellowModule.ApiService` | API service for the Yellow module |

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download) (or compatible version per `global.json` with `rollForward: latestFeature`)
- [.NET Aspire workload](https://learn.microsoft.com/en-us/dotnet/aspire/fundamentals/setup-tooling)
- Docker (optional, for containerized services like the HTMX server)

Install the Aspire workload:

```bash
dotnet workload update
dotnet workload install aspire
```

## Getting Started

1. **Clone the repository**

   ```bash
   git clone https://github.com/phmatray/AspireAppWithMicroFrontends.git
   cd AspireAppWithMicroFrontends
   ```

2. **Restore dependencies**

   ```bash
   dotnet restore
   ```

3. **Run the Aspire AppHost**

   ```bash
   dotnet run --project src/Host/AspireAppWithMicroFrontends.AppHost
   ```

   This starts all services and opens the Aspire dashboard where you can monitor logs, traces, and health for every service.

4. **Open the dashboard**

   The Aspire dashboard URL is displayed in the console output (typically `https://localhost:17225`). From there, you can navigate to each frontend shell and API endpoint.

## Solution Filters

The repository includes solution filters (`.slnf` files in `filters/`) to load only a subset of projects in your IDE:

- `Blue.slnf` — Host + Blue module only
- `Green.slnf` — Host + Green module only
- `Red.slnf` — Host + Red module only
- `Yellow.slnf` — Host + Yellow module only
- `Black.slnf` — Host projects only

## Module Architecture

Each color-coded module follows a consistent four-project structure:

| Layer | Project | Responsibility |
|-------|---------|----------------|
| **Web** | `{Color}Module.Web` | Blazor components exposed to shell apps |
| **ApiService** | `{Color}Module.ApiService` | ASP.NET Core Minimal API or controller-based service |
| **ApiClient** | `{Color}Module.ApiClient` | Typed `HttpClient` for consuming the API |
| **Domain** | `{Color}Module.Domain` | Domain models, entities, and business logic |

Shell applications compose modules by referencing their `*.Web` projects and registering their Blazor components via `AddAdditionalAssemblies()`.

## Code Quality

The solution enforces strict code analysis via `Directory.Build.props`:

- .NET analyzers enabled at the `8.0-recommended` level
- All analysis categories set to `All` (design, naming, performance, security, etc.)
- `Microsoft.CodeAnalysis.NetAnalyzers` included as a build-time dependency

## License

See the repository for license details.

---

<!-- portfolio-sections:start -->

## Contributing

Contributions are welcome. Open an issue first to discuss any significant change.

1. Fork the repository and create your branch (`git checkout -b feat/my-feature`)
2. Commit your changes (`git commit -m 'feat: ...'`)
3. Push the branch and open a Pull Request

<!-- portfolio-sections:end -->
