# AspireContainer — .NET Aspire Container Orchestration Demo

A demonstration project for .NET Aspire container orchestration. Shows how to compose multi-service applications using the Aspire App Host and service defaults.

## ✨ Features
- .NET Aspire App Host setup
- Multi-container service composition
- Service discovery and health checks
- Environment configuration

## 📦 Installation
```bash
dotnet run --project AspireContainer.AppHost
```

## 🚀 Quick Start
```csharp
var builder = DistributedApplication.CreateBuilder(args);
builder.AddProject<Projects.AspireContainer_Demo>("demo");
builder.Build().Run();
```

## 📄 License
MIT — see LICENSE
