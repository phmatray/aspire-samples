namespace HtmxAppServer.Pages.Authenticated;

public class TransactionsEndpoint
    : HtmxComponentEndpoint<Transactions, TransactionsEndpoint.TransactionsParameters>
{
    public override void Configure()
    {
        Get(RouteTransactions);
        AllowAnonymous();
    }

    public record TransactionsParameters
        : HtmxComponentParameters;
}