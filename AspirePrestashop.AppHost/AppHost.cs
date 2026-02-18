var builder = DistributedApplication.CreateBuilder(args);

// Add MySQL database for PrestaShop
var mysql = builder.AddMySql("mysql")
    .WithImage("mysql", "8.0")
    .WithEnvironment("MYSQL_ROOT_PASSWORD", "PrestaShop123!")
    .WithDataVolume("prestashop-mysql-data");
var prestashopDb = mysql.AddDatabase("prestashop");

// Add PrestaShop container
var prestashop = builder.AddContainer("prestashop-app", "prestashop/prestashop", "8-apache")
    .WithHttpEndpoint(port: 8080, targetPort: 80, name: "http")
    .WithEnvironment("PS_INSTALL_AUTO", "1")
    .WithEnvironment("PS_DOMAIN", "localhost:8080")
    .WithEnvironment("PS_FOLDER_ADMIN", "admin123")
    .WithEnvironment("PS_FOLDER_INSTALL", "install123")
    .WithEnvironment("PS_LANGUAGE", "en")
    .WithEnvironment("PS_COUNTRY", "US")
    .WithEnvironment("PS_ENABLE_SSL", "0")
    .WithEnvironment("PS_DEV_MODE", "1")
    .WithEnvironment("DB_SERVER", "mysql")
    .WithEnvironment("DB_NAME", "prestashop")
    .WithEnvironment("DB_USER", "root")
    .WithEnvironment("DB_PASSWD", "PrestaShop123!")
    .WithEnvironment("DB_PREFIX", "ps_")
    .WithEnvironment("ADMIN_MAIL", "admin@example.com")
    .WithEnvironment("ADMIN_PASSWD", "Admin123!")
    .WithVolume("prestashop-data", "/var/www/html")
    .WithHttpHealthCheck("/")
    .WaitFor(prestashopDb);

var apiService = builder.AddProject<Projects.AspirePrestashop_ApiService>("apiservice")
    .WithHttpHealthCheck("/health")
    .WithEnvironment("PrestaShop__BaseUrl", prestashop.GetEndpoint("http"))
    .WithEnvironment("PrestaShop__ApiKey", "YOUR_API_KEY_HERE");

builder.AddProject<Projects.AspirePrestashop_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();