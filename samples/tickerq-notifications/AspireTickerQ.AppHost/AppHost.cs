var builder = DistributedApplication.CreateBuilder(args);

// Configure the Docker Compose environment
builder.AddDockerComposeEnvironment("env");

// SQL Server with persistent lifetime for faster restarts
// Use Azure SQL Edge for ARM64 (Apple Silicon) compatibility
var sqlServer = builder.AddSqlServer("sql")
    .WithImage("azure-sql-edge")
    .WithLifetime(ContainerLifetime.Persistent);

// Application database for domain entities (Users, Notifications)
var appDatabase = sqlServer.AddDatabase("appdb");

// TickerQ operational database for job persistence
var tickerQDatabase = sqlServer.AddDatabase("tickerqdb");

// MailHog container for development SMTP testing
var mailhog = builder.AddContainer("mailhog", "mailhog/mailhog")
    .WithHttpEndpoint(port: 8025, targetPort: 8025, name: "ui")
    .WithEndpoint(port: 1025, targetPort: 1025, name: "smtp");

// API project with database reference
var apiService = builder.AddProject<Projects.AspireTickerQ_Api>("api")
    .WithExternalHttpEndpoints()
    .WithReference(appDatabase)
    .WaitFor(appDatabase);

// Worker project with both databases
var workerService = builder.AddProject<Projects.AspireTickerQ_Worker>("worker")
    .WithReference(appDatabase)
    .WithReference(tickerQDatabase)
    .WaitFor(appDatabase)
    .WaitFor(tickerQDatabase)
    .WaitFor(mailhog); // Wait for MailHog to start, but connect via SMTP settings

builder.Build().Run();
