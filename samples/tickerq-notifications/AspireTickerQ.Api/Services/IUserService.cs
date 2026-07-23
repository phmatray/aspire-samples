using AspireTickerQ.Shared.Models;

namespace AspireTickerQ.Api.Services;

public interface IUserService
{
    Task<User> RegisterUserAsync(string email, string name);
}
