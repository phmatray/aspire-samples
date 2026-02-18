namespace AspirePrestashop.Web;

public class PrestaShopApiClient(HttpClient httpClient)
{
    public async Task<Product[]> GetProductsAsync(int maxItems = 10, CancellationToken cancellationToken = default)
    {
        List<Product>? products = null;

        await foreach (var product in httpClient.GetFromJsonAsAsyncEnumerable<Product>("/api/prestashop/products", cancellationToken))
        {
            if (products?.Count >= maxItems)
            {
                break;
            }
            if (product is not null)
            {
                products ??= [];
                products.Add(product);
            }
        }

        return products?.ToArray() ?? [];
    }

    public async Task<Category[]> GetCategoriesAsync(CancellationToken cancellationToken = default)
    {
        return await httpClient.GetFromJsonAsync<Category[]>("/api/prestashop/categories", cancellationToken) ?? [];
    }

    public async Task<Customer[]> GetCustomersAsync(CancellationToken cancellationToken = default)
    {
        return await httpClient.GetFromJsonAsync<Customer[]>("/api/prestashop/customers", cancellationToken) ?? [];
    }

    public async Task<Order[]> GetOrdersAsync(CancellationToken cancellationToken = default)
    {
        return await httpClient.GetFromJsonAsync<Order[]>("/api/prestashop/orders", cancellationToken) ?? [];
    }
}

public record Product(
    int Id,
    string Name,
    string Description,
    decimal Price,
    int Quantity,
    bool Active,
    string Reference,
    string ImageUrl
);

public record Category(
    int Id,
    string Name,
    string Description,
    int ParentId,
    bool Active
);

public record Customer(
    int Id,
    string Email,
    string FirstName,
    string LastName,
    DateTime DateAdd
);

public record Order(
    int Id,
    string Reference,
    decimal TotalPaid,
    string PaymentMethod,
    DateTime DateAdd,
    string CurrentState
);