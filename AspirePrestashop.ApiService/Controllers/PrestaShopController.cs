using AspirePrestashop.ApiService.Models;
using AspirePrestashop.ApiService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspirePrestashop.ApiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrestaShopController : ControllerBase
{
    private readonly PrestaShopApiClient _prestaShopClient;
    private readonly ILogger<PrestaShopController> _logger;

    public PrestaShopController(PrestaShopApiClient prestaShopClient, ILogger<PrestaShopController> logger)
    {
        _prestaShopClient = prestaShopClient;
        _logger = logger;
    }

    [HttpGet("products")]
    public async Task<IActionResult> GetProducts()
    {
        var xmlProducts = await _prestaShopClient.GetProductsAsync();
        if (xmlProducts == null)
            return StatusCode(503, "PrestaShop service unavailable");

        var products = new List<Product>();
        
        // Parse XML and convert to DTOs
        var productElements = xmlProducts.Descendants("product");
        foreach (var element in productElements)
        {
            // This is a simplified example - actual PrestaShop XML structure may vary
            products.Add(new Product(
                Id: int.Parse(element.Attribute("id")?.Value ?? "0"),
                Name: element.Element("name")?.Value ?? "",
                Description: element.Element("description")?.Value ?? "",
                Price: decimal.Parse(element.Element("price")?.Value ?? "0"),
                Quantity: int.Parse(element.Element("quantity")?.Value ?? "0"),
                Active: element.Element("active")?.Value == "1",
                Reference: element.Element("reference")?.Value ?? "",
                ImageUrl: element.Element("image_url")?.Value ?? ""
            ));
        }

        return Ok(products);
    }

    [HttpGet("products/{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var xmlProduct = await _prestaShopClient.GetProductAsync(id);
        if (xmlProduct == null)
            return NotFound();

        // Parse XML and convert to DTO
        var productElement = xmlProduct.Descendants("product").FirstOrDefault();
        if (productElement == null)
            return NotFound();

        var product = new Product(
            Id: id,
            Name: productElement.Element("name")?.Value ?? "",
            Description: productElement.Element("description")?.Value ?? "",
            Price: decimal.Parse(productElement.Element("price")?.Value ?? "0"),
            Quantity: int.Parse(productElement.Element("quantity")?.Value ?? "0"),
            Active: productElement.Element("active")?.Value == "1",
            Reference: productElement.Element("reference")?.Value ?? "",
            ImageUrl: productElement.Element("image_url")?.Value ?? ""
        );

        return Ok(product);
    }

    [HttpGet("categories")]
    public async Task<IActionResult> GetCategories()
    {
        var xmlCategories = await _prestaShopClient.GetCategoriesAsync();
        if (xmlCategories == null)
            return StatusCode(503, "PrestaShop service unavailable");

        var categories = new List<Category>();
        
        // Parse XML and convert to DTOs
        var categoryElements = xmlCategories.Descendants("category");
        foreach (var element in categoryElements)
        {
            categories.Add(new Category(
                Id: int.Parse(element.Attribute("id")?.Value ?? "0"),
                Name: element.Element("name")?.Value ?? "",
                Description: element.Element("description")?.Value ?? "",
                ParentId: int.Parse(element.Element("id_parent")?.Value ?? "0"),
                Active: element.Element("active")?.Value == "1"
            ));
        }

        return Ok(categories);
    }

    [HttpGet("customers")]
    public async Task<IActionResult> GetCustomers()
    {
        var xmlCustomers = await _prestaShopClient.GetCustomersAsync();
        if (xmlCustomers == null)
            return StatusCode(503, "PrestaShop service unavailable");

        var customers = new List<Customer>();
        
        // Parse XML and convert to DTOs
        var customerElements = xmlCustomers.Descendants("customer");
        foreach (var element in customerElements)
        {
            customers.Add(new Customer(
                Id: int.Parse(element.Attribute("id")?.Value ?? "0"),
                Email: element.Element("email")?.Value ?? "",
                FirstName: element.Element("firstname")?.Value ?? "",
                LastName: element.Element("lastname")?.Value ?? "",
                DateAdd: DateTime.Parse(element.Element("date_add")?.Value ?? DateTime.Now.ToString())
            ));
        }

        return Ok(customers);
    }

    [HttpGet("orders")]
    public async Task<IActionResult> GetOrders()
    {
        var xmlOrders = await _prestaShopClient.GetOrdersAsync();
        if (xmlOrders == null)
            return StatusCode(503, "PrestaShop service unavailable");

        var orders = new List<Order>();
        
        // Parse XML and convert to DTOs
        var orderElements = xmlOrders.Descendants("order");
        foreach (var element in orderElements)
        {
            orders.Add(new Order(
                Id: int.Parse(element.Attribute("id")?.Value ?? "0"),
                Reference: element.Element("reference")?.Value ?? "",
                TotalPaid: decimal.Parse(element.Element("total_paid")?.Value ?? "0"),
                PaymentMethod: element.Element("payment")?.Value ?? "",
                DateAdd: DateTime.Parse(element.Element("date_add")?.Value ?? DateTime.Now.ToString()),
                CurrentState: element.Element("current_state")?.Value ?? ""
            ));
        }

        return Ok(orders);
    }
}