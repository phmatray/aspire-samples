using Microsoft.AspNetCore.Components.Web;

namespace HtmxAppServer.Utils;

public sealed class CustomErrorBoundaryLogger(ILogger<ErrorBoundary> errorBoundaryLogger)
    : IErrorBoundaryLogger
{
    private readonly ILogger<ErrorBoundary> _errorBoundaryLogger =
        errorBoundaryLogger
        ?? throw new ArgumentNullException(nameof(errorBoundaryLogger));

    public ValueTask LogErrorAsync(Exception exception)
    {
        // For, client-side code, all internal state is visible to the end user. We can just
        // log directly to the console.
        _errorBoundaryLogger.LogError(exception, exception.ToString());
        return ValueTask.CompletedTask;
    }
}