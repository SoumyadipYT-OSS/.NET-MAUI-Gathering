using _05_DependencyInjection.Services;

namespace _05_DependencyInjection.ViewModels;

public sealed class SingletonExampleViewModel(IAppConfig config, ILoggingService logging) : ViewModelBase
{
    public string Explanation =>
        "Singleton services are created once and shared for the entire app lifetime.\n" +
        "They are ideal for shared state (carefully), configuration, or expensive-to-create services.";

    public string EnvironmentName => config.EnvironmentName;
    public string ApiBaseUrl => config.ApiBaseUrl;

    public void Log()
    {
        logging.Log($"Singleton example: Environment='{EnvironmentName}', ApiBaseUrl='{ApiBaseUrl}'.");
    }
}
