using AspireTickerQ.Shared.Data;
using AspireTickerQ.Shared.DTOs;
using AspireTickerQ.Shared.Models;
using TickerQ.Utilities;
using TickerQ.Utilities.Entities;
using TickerQ.Utilities.Interfaces.Managers;

namespace AspireTickerQ.Api.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;
    private readonly ITimeTickerManager<TimeTickerEntity> _timeTickerManager;
    private readonly ILogger<UserService> _logger;

    public UserService(
        AppDbContext context,
        ITimeTickerManager<TimeTickerEntity> timeTickerManager,
        ILogger<UserService> logger)
    {
        _context = context;
        _timeTickerManager = timeTickerManager;
        _logger = logger;
    }

    public async Task<User> RegisterUserAsync(string email, string name)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = email,
            Name = name,
            CreatedAt = DateTime.UtcNow
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        _logger.LogInformation("User {UserId} registered: {Email}", user.Id, email);

        // Schedule welcome email for 5 minutes from now
        await _timeTickerManager.AddAsync(new TimeTickerEntity
        {
            Function = "SendWelcomeEmail",
            ExecutionTime = DateTime.UtcNow.AddMinutes(5),
            Request = TickerHelper.CreateTickerRequest(new WelcomeEmailRequest
            {
                Email = email,
                Name = name,
                UserId = user.Id
            }),
            Description = $"Welcome email for {email}",
            Retries = 3,
            RetryIntervals = new[] { 60, 300, 900 } // 1min, 5min, 15min
        });

        _logger.LogInformation("Welcome email scheduled for user {UserId}", user.Id);

        return user;
    }
}
