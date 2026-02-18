using System.Net.Http.Headers;
using System.Text;
using System.Xml.Linq;

namespace AspirePrestashop.ApiService.Services;

public class PrestaShopApiClient
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly ILogger<PrestaShopApiClient> _logger;

    public PrestaShopApiClient(HttpClient httpClient, IConfiguration configuration, ILogger<PrestaShopApiClient> logger)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _logger = logger;
        
        ConfigureHttpClient();
    }

    private void ConfigureHttpClient()
    {
        var baseUrl = _configuration["PrestaShop:BaseUrl"] ?? "http://localhost:8080";
        var apiKey = _configuration["PrestaShop:ApiKey"] ?? "";
        
        _httpClient.BaseAddress = new Uri($"{baseUrl}/api/");
        _httpClient.DefaultRequestHeaders.Authorization = 
            new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{apiKey}:")));
    }

    public async Task<XDocument?> GetProductsAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("products");
            response.EnsureSuccessStatusCode();
            
            var content = await response.Content.ReadAsStringAsync();
            return XDocument.Parse(content);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching products from PrestaShop");
            return null;
        }
    }

    public async Task<XDocument?> GetProductAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"products/{id}");
            response.EnsureSuccessStatusCode();
            
            var content = await response.Content.ReadAsStringAsync();
            return XDocument.Parse(content);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching product {ProductId} from PrestaShop", id);
            return null;
        }
    }

    public async Task<XDocument?> GetCategoriesAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("categories");
            response.EnsureSuccessStatusCode();
            
            var content = await response.Content.ReadAsStringAsync();
            return XDocument.Parse(content);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching categories from PrestaShop");
            return null;
        }
    }

    public async Task<XDocument?> GetOrdersAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("orders");
            response.EnsureSuccessStatusCode();
            
            var content = await response.Content.ReadAsStringAsync();
            return XDocument.Parse(content);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching orders from PrestaShop");
            return null;
        }
    }

    public async Task<XDocument?> GetCustomersAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("customers");
            response.EnsureSuccessStatusCode();
            
            var content = await response.Content.ReadAsStringAsync();
            return XDocument.Parse(content);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching customers from PrestaShop");
            return null;
        }
    }
}