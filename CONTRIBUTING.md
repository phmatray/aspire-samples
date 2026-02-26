# Contributing to AspireAppWithMicroFrontends

Thank you for your interest in contributing! This guide will help you get started with the project and ensure a smooth collaboration process.

## How to Contribute

1. **Fork** the repository on GitHub.
2. **Clone** your fork locally.
3. **Create a branch** for your changes (see [Development Setup](#development-setup)).
4. **Make your changes**, following the guidelines below.
5. **Submit a pull request** against the `main` branch.

## Development Setup

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download) (see `global.json` for the pinned version — currently `10.0.103`)
- [.NET Aspire workload](https://learn.microsoft.com/en-us/dotnet/aspire/fundamentals/setup-tooling) installed:
  ```bash
  dotnet workload install aspire
  ```
- A compatible IDE such as Visual Studio 2022+, JetBrains Rider, or VS Code with the C# Dev Kit

### Build

Restore dependencies and build the solution:

```bash
dotnet restore
dotnet build
```

### Run

Start the Aspire application via the AppHost project:

```bash
dotnet run --project src/Host/AspireAppWithMicroFrontends.AppHost
```

This will launch the Aspire dashboard and orchestrate all services (API services, web shells, BFF gateway, and micro-frontend modules).

### Test

Run all tests from the solution root:

```bash
dotnet test
```

## Pull Request Process

1. Create a feature branch from `main`:
   ```bash
   git checkout -b feature/your-feature-name
   ```
2. Keep your changes focused — one logical change per PR.
3. Update documentation if your changes affect public APIs or project setup.
4. Ensure the solution builds without errors or warnings:
   ```bash
   dotnet build --warnaserrors
   ```
5. Ensure all tests pass before submitting.
6. Push your branch and open a pull request against `main`.
7. Wait for CI checks to pass and address any review feedback.

## Code Style

This project enforces code style at build time via `EnforceCodeStyleInBuild` and .NET analyzers (see `Directory.Build.props`). All analyzer categories are set to **All**, so the build will flag style, naming, performance, reliability, and other issues automatically.

Before committing, run:

```bash
dotnet format
```

This ensures your code conforms to the project's style rules. Key conventions include:

- **Nullable reference types** are enabled — avoid unguarded nullable dereferences.
- **Implicit usings** are enabled — do not add redundant `using` directives for common namespaces.
- Follow standard C# naming conventions (PascalCase for public members, camelCase with underscore prefix for private fields).

## Project Architecture

The solution follows a modular micro-frontend architecture with .NET Aspire orchestration:

- **`src/Host/`** — Aspire AppHost (orchestrator), ServiceDefaults, and the main Web project
- **`src/Modules/`** — Independent feature modules (Blue, Green, Red, Yellow), each with ApiClient, ApiService, Domain, and Web layers
- **`src/WasmShell/`** and **`src/WebShell/`** — Blazor shell applications
- **`src/Web.Bff.Gateway/`** — Backend-for-Frontend gateway
- **`src/HtmxAppServer/`** — HTMX-based app server

When adding a new module, follow the existing pattern of the color-named modules.

## Reporting Issues

- Use the [GitHub issue tracker](https://github.com/phmatray/AspireAppWithMicroFrontends/issues).
- Check existing issues before creating a new one.
- Provide clear reproduction steps and relevant environment details.

## Code of Conduct

Please be respectful and constructive in all interactions. We are committed to providing a welcoming and inclusive experience for everyone.
