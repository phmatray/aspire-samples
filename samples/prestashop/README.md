![AspirePrestashop banner](.github/banner.png)

# AspirePrestashop - PrestaShop Integration with .NET Aspire

<!-- portfolio-badges:start -->
<!-- Identity -->
[![phmatray - AspirePrestashop](https://img.shields.io/static/v1?label=phmatray&message=AspirePrestashop&color=blue&logo=github)](https://github.com/phmatray/AspirePrestashop)
![Top language](https://img.shields.io/github/languages/top/phmatray/AspirePrestashop)
[![Stars](https://img.shields.io/github/stars/phmatray/AspirePrestashop?style=social)](https://github.com/phmatray/AspirePrestashop/stargazers)
[![Forks](https://img.shields.io/github/forks/phmatray/AspirePrestashop?style=social)](https://github.com/phmatray/AspirePrestashop/network/members)

<!-- Activity -->
[![Issues](https://img.shields.io/github/issues/phmatray/AspirePrestashop)](https://github.com/phmatray/AspirePrestashop/issues)
[![Pull requests](https://img.shields.io/github/issues-pr/phmatray/AspirePrestashop)](https://github.com/phmatray/AspirePrestashop/pulls)
[![Last commit](https://img.shields.io/github/last-commit/phmatray/AspirePrestashop)](https://github.com/phmatray/AspirePrestashop/commits)
<!-- portfolio-badges:end -->

<!-- portfolio-toc:start -->

## Table of Contents

- [Architecture](#architecture)
- [Components](#components)
- [Setup](#setup)
- [Notes](#notes)
- [Tech Stack](#tech-stack)
- [Contributing](#contributing)
- [License](#license)

<!-- portfolio-toc:end -->



This project demonstrates how to integrate PrestaShop with .NET Aspire using Docker containers and REST API.

## Features

- **PrestaShop container orchestration**: The Aspire `AppHost` spins up a PrestaShop 8 (Apache) container plus a MySQL 8 database, auto-installing the shop (`PS_INSTALL_AUTO=1`) with a fixed admin login and persisted Docker volumes.
- **REST bridge to PrestaShop's Web Service**: `PrestaShopApiClient` authenticates with a PrestaShop API key and parses PrestaShop's XML responses into typed DTOs (`Product`, `Category`, `Customer`, `Order`).
- **Product/Category/Customer/Order API**: `PrestaShopController` exposes `/api/prestashop/products[/{id}]`, `/categories`, `/customers` and `/orders` as JSON via the ApiService.
- **Blazor product catalog page**: `Products.razor` calls the API service and renders the product list (ID, reference, name, price, quantity, active) in a table.
- **Resilience & service discovery by default**: `ServiceDefaults.AddServiceDefaults` wires a standard HTTP resilience handler and service discovery into every `HttpClient`.
- **Built-in observability**: OpenTelemetry tracing/metrics plus `/health` and `/alive` health-check endpoints are configured for every service and surfaced in the Aspire dashboard.
- **Health-gated startup**: The AppHost uses `WithHttpHealthCheck` and `WaitFor` so the API and web frontend wait for PrestaShop/MySQL to be ready before serving traffic.

## Architecture

- **AspirePrestashop.AppHost**: Orchestrates the application components
- **AspirePrestashop.ApiService**: Provides API endpoints to interact with PrestaShop
- **AspirePrestashop.Web**: Blazor web application that displays PrestaShop data
- **AspirePrestashop.ServiceDefaults**: Shared service configuration

## Components

### PrestaShop Container
- Running on port 8080
- Admin panel: http://localhost:8080/admin123
- Default credentials: admin@example.com / Admin123!

### MySQL Database
- Used by PrestaShop
- Password stored as a parameter in Aspire

### API Endpoints
- `/api/prestashop/products` - List products
- `/api/prestashop/products/{id}` - Get specific product
- `/api/prestashop/categories` - List categories  
- `/api/prestashop/customers` - List customers
- `/api/prestashop/orders` - List orders

## Setup

1. Enable PrestaShop Web API:
   - Access PrestaShop admin panel
   - Go to Advanced Parameters > Webservice
   - Enable webservice
   - Create a new API key with full permissions
   - Update the API key in AppHost.cs

2. Run the application:
   ```bash
   dotnet run --project AspirePrestashop.AppHost
   ```

3. Access the services:
   - Aspire Dashboard: http://localhost:15XXX
   - Web Frontend: http://localhost:5XXX
   - API Service: http://localhost:5XXX
   - PrestaShop: http://localhost:8080

## Usage

Once the AppHost is running, browse the Blazor catalog at `http://localhost:5XXX/products`, or call the ApiService directly:

```bash
curl http://localhost:5XXX/api/prestashop/products
curl http://localhost:5XXX/api/prestashop/products/1
curl http://localhost:5XXX/api/prestashop/categories
curl http://localhost:5XXX/api/prestashop/customers
curl http://localhost:5XXX/api/prestashop/orders
```

Each endpoint fetches XML from PrestaShop's Web Service and returns it as JSON. Use the Aspire Dashboard to inspect traces, logs and health status across the PrestaShop container, MySQL, the API service and the web frontend.

## Notes

- PrestaShop container will auto-install on first run
- Data is persisted using Docker volumes
- The integration uses PrestaShop's REST API with XML responses

---

<!-- portfolio-techstack:start -->

## Tech Stack

- **.NET 9**
- Microsoft.AspNetCore.OpenApi
- Aspire.Hosting.AppHost
- Aspire.Hosting.MySql
- Microsoft.Extensions.Http.Resilience
- Microsoft.Extensions.ServiceDiscovery
- OpenTelemetry.Exporter.OpenTelemetryProtocol
- OpenTelemetry.Extensions.Hosting
- OpenTelemetry.Instrumentation.AspNetCore

<!-- portfolio-techstack:end -->

<!-- portfolio-roadmap:start -->

## Roadmap

Planned work and known limitations are tracked in the [open issues](https://github.com/phmatray/AspirePrestashop/issues). Contributions toward them are welcome.

<!-- portfolio-roadmap:end -->

<!-- portfolio-sections:start -->

## Contributing

Contributions are welcome. Open an issue first to discuss any significant change.

1. Fork the repository and create your branch (`git checkout -b feat/my-feature`)
2. Commit your changes (`git commit -m 'feat: ...'`)
3. Push the branch and open a Pull Request

## License

No license has been declared for this repository yet. Until one is added, default copyright applies — see [choosealicense.com](https://choosealicense.com/) if you intend to open it up.

<!-- portfolio-sections:end -->
