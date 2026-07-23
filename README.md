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


This project demonstrates how to integrate PrestaShop with .NET Aspire using Docker containers and REST API.

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

<!-- portfolio-sections:start -->

## Contributing

Contributions are welcome. Open an issue first to discuss any significant change.

1. Fork the repository and create your branch (`git checkout -b feat/my-feature`)
2. Commit your changes (`git commit -m 'feat: ...'`)
3. Push the branch and open a Pull Request

## License

No license has been declared for this repository yet. Until one is added, default copyright applies — see [choosealicense.com](https://choosealicense.com/) if you intend to open it up.

<!-- portfolio-sections:end -->
