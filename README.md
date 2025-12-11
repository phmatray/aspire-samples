# AspireTickerQ

A production-ready notification system built with .NET Aspire and TickerQ, demonstrating scheduled background jobs, user registration, and email notifications.

## Architecture

This is a .NET Aspire distributed application with the following projects:

- **AspireTickerQ.AppHost** - Orchestrates all services and dependencies
- **AspireTickerQ.ServiceDefaults** - Shared Aspire configurations (service discovery, health checks, OpenTelemetry)
- **AspireTickerQ.Shared** - Domain models (User, Notification) and DTOs shared between projects
- **AspireTickerQ.Api** - REST API for user registration that schedules jobs
- **AspireTickerQ.Worker** - Background job processor using TickerQ

## Features

✅ User registration API endpoint
✅ Welcome email scheduled 5 minutes after registration
✅ Daily digest at 9 AM with 24h notification summary
✅ Cleanup job at midnight removing 30+ day old notifications
✅ Custom exception handler with SMTP failure alerting
✅ Exponential backoff retry strategy (60s, 5min, 15min)
✅ Separate databases for app data and TickerQ operations
✅ Development SMTP server via MailHog container
✅ .NET Aspire orchestration with service discovery

## Prerequisites

- .NET 9 SDK or later
- Docker Desktop (for SQL Server and MailHog containers)
- IDE: Visual Studio 2024+, JetBrains Rider, or VS Code

## Quick Start

1. **Clone the repository**
   ```bash
   cd AspireTickerQ
   ```

2. **Run the Aspire AppHost**
   ```bash
   dotnet run --project AspireTickerQ.AppHost
   ```

   This will:
   - Start SQL Server container with persistent storage
   - Create `appdb` and `tickerqdb` databases
   - Start MailHog SMTP server on port 1025 (UI on port 8025)
   - Launch the API service
   - Launch the Worker service

3. **Access the Aspire Dashboard**

   Open your browser to the URL shown in the console (usually `http://localhost:15001` or similar). The Aspire Dashboard shows:
   - All running services and containers
   - Live logs from each service
   - Distributed traces
   - Metrics and health status

## Testing the Application

### 1. Test User Registration

Register a new user via the API:

```bash
curl -X POST http://localhost:<api-port>/api/users/register \
  -H "Content-Type: application/json" \
  -d '{"email": "test@example.com", "name": "Test User"}'
```

Expected response:
```json
{
  "userId": "guid-here"
}
```

### 2. Verify Welcome Email Job Scheduled

- Check the Worker logs in the Aspire Dashboard
- You should see: "Welcome email scheduled for user {userId}"
- The welcome email will be sent after 5 minutes

### 3. View Sent Emails in MailHog

1. Open MailHog UI: `http://localhost:8025`
2. Wait 5 minutes after registration
3. You should see the welcome email with subject "Welcome to TickerQ!"

### 4. Test Daily Digest (Manual Trigger)

Since the daily digest runs at 9 AM, you can test it by:

1. Inserting test notifications into the database
2. Manually adjusting the cron expression to run immediately
3. Or waiting until 9 AM the next day

### 5. Test Cleanup Job (Manual Trigger)

1. Insert notifications with `CreatedAt` set to 31+ days ago
2. Wait for midnight or adjust the cron expression
3. Verify old notifications are deleted

## Database Access

Connect to the SQL Server database:

- **Server**: `localhost,<dynamic-port>` (see Aspire Dashboard for exact port)
- **Username**: `sa`
- **Password**: (generated, shown in Aspire Dashboard)
- **Databases**:
  - `appdb` - User and Notification tables
  - `tickerqdb` - TickerQ operational data (job state, history)

## Configuration

### SMTP Settings (Worker)

Edit `AspireTickerQ.Worker/appsettings.json`:

```json
{
  "SmtpSettings": {
    "Host": "localhost",
    "Port": 1025,
    "Username": "",
    "Password": "",
    "UseSsl": false,
    "FromEmail": "noreply@tickerq.local",
    "FromName": "TickerQ Notifications"
  }
}
```

### TickerQ Configuration

- **Max Concurrency**: 10 jobs running simultaneously
- **Node Identifier**: Machine name
- **Retry Policy**: 3 attempts with exponential backoff (60s, 5min, 15min)
- **Database Retry**: 3 attempts, 5-second max delay

## Project Structure

```
AspireTickerQ/
├── AspireTickerQ.AppHost/
│   └── AppHost.cs                          # Service orchestration
├── AspireTickerQ.ServiceDefaults/
│   └── Extensions.cs                        # Shared configurations
├── AspireTickerQ.Shared/
│   ├── Models/
│   │   ├── User.cs
│   │   └── Notification.cs
│   ├── DTOs/
│   │   ├── RegisterRequest.cs
│   │   └── WelcomeEmailRequest.cs
│   └── Data/
│       └── AppDbContext.cs
├── AspireTickerQ.Api/
│   ├── Program.cs                           # API configuration & endpoints
│   └── Services/
│       ├── IUserService.cs
│       └── UserService.cs                   # User registration + job scheduling
└── AspireTickerQ.Worker/
    ├── Program.cs                           # TickerQ configuration
    ├── Services/
    │   ├── SmtpSettings.cs
    │   ├── IEmailService.cs
    │   └── EmailService.cs                  # MailKit SMTP implementation
    └── Jobs/
        ├── WelcomeEmailJob.cs               # Time-based job (5 min delay)
        ├── DailyDigestJob.cs                # Cron job (9 AM daily)
        ├── CleanupJob.cs                    # Cron job (midnight)
        └── NotificationExceptionHandler.cs  # Custom error handling
```

## Scheduled Jobs

### WelcomeEmailJob
- **Type**: Time-based (delayed execution)
- **Trigger**: 5 minutes after user registration
- **Function**: `SendWelcomeEmail`
- **Retries**: 3 (60s, 5min, 15min backoff)
- **Description**: Sends welcome email to newly registered users

### DailyDigestJob
- **Type**: Cron-based
- **Schedule**: `0 0 9 * * *` (9:00 AM daily)
- **Function**: `SendDailyDigest`
- **Description**: Aggregates last 24h notifications and emails users

### CleanupJob
- **Type**: Cron-based
- **Schedule**: `0 0 0 * * *` (midnight daily)
- **Function**: `CleanupOldNotifications`
- **Description**: Removes notifications older than 30 days

## Production Deployment

Before deploying to production:

1. **Replace MailHog** with a real SMTP service (SendGrid, AWS SES, Office 365)
2. **Use EF Migrations** instead of `EnsureCreatedAsync()`
   ```bash
   dotnet ef migrations add InitialCreate --context AppDbContext
   dotnet ef database update
   ```
3. **Secure Connection Strings** using Azure Key Vault or user secrets
4. **Configure Strong Passwords** for dashboard (if using a web-hosted dashboard)
5. **Enable HTTPS** for all endpoints
6. **Configure OpenTelemetry** exports to Application Insights or Jaeger
7. **Scale Worker** instances based on job queue depth

## Troubleshooting

### Jobs Not Executing

- Check Worker logs in Aspire Dashboard
- Verify TickerQ operational database is created
- Ensure AppDbContext migrations are applied

### Emails Not Sending

- Verify MailHog container is running (`docker ps`)
- Check Worker logs for SMTP connection errors
- Verify SMTP settings in `appsettings.json`
- Open MailHog UI at `http://localhost:8025`

### Database Connection Errors

- Check SQL Server container status in Aspire Dashboard
- Verify connection strings are injected correctly
- Check if databases are created (should happen automatically on startup)

## Technologies Used

- **.NET 9** - Latest .NET framework
- **.NET Aspire** - Cloud-native application orchestration
- **TickerQ 10.x** - Background job scheduler with EF Core persistence
- **Entity Framework Core** - ORM for database access
- **MailKit** - Modern SMTP client library
- **SQL Server** - Database for application and job data
- **MailHog** - Development SMTP server

## License

This project is licensed under the MIT License.

## Acknowledgments

Based on the [TickerQ Complete Example](https://tickerq.net/examples/complete-example.html).
