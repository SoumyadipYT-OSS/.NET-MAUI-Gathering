using Microsoft.Extensions.Logging;

namespace _05_DependencyInjection.Services;

public sealed class DebugLoggingService(ILogger<DebugLoggingService> logger) : ILoggingService
{
    public void Log(string message)
    {
        // Wrapping the built-in ILogger keeps the demo focused on DI concepts
        // while still using a real logger implementation.
        logger.LogInformation("{Message}", message);
    }
}
