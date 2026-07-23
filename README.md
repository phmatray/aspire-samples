![AspirePrestashop banner](.github/banner.png)

# AspirePrestashop - PrestaShop Integration with .NET Aspire

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