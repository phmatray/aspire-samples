namespace HtmxAppServer.Features.Transactions.Models;

public record TransactionModel(
    string Id,
    string Name,
    string Email,
    string Location,
    string Avatar,
    decimal Amount,
    DateTime Date);
