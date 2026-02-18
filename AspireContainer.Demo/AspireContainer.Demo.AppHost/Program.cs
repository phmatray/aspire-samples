var builder = DistributedApplication.CreateBuilder(args);

builder.AddRedisContainer("redis");
builder.AddPostgresContainer("postgres");
builder.AddRabbitMQContainer("rabbitmq");

// FileBrowser
builder
    .AddFileBrowserContainer("filebrowser", port: 8080)
    .WithVolumeMount("../containers/filebrowser/data", "/srv")
    .WithVolumeMount("../containers/filebrowser/database.db", "/database.db");
    // .WithVolumeMount("../containers/filebrowser/.filebrowser.json", "/.filebrowser.json");

// Flame
builder
    .AddFlameContainer("flame", password: "flame")
    .WithVolumeMount("../containers/flame/data", "/app/data");

// Plex
builder
    .AddPlexContainer("plex", timeZone: "Europe/Brussels")
    .WithVolumeMount("../containers/plex/config", "/config")
    .WithVolumeMount("../movies", "/movies");

builder.Build().Run();