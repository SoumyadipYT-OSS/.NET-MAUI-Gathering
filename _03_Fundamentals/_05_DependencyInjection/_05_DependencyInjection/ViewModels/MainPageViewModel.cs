using System.Windows.Input;
using _05_DependencyInjection.Services;

namespace _05_DependencyInjection.ViewModels;

public sealed class MainPageViewModel(IAppConfig config, ILoggingService logging) : ViewModelBase
{
    public string Title => "Dependency Injection (DI) Fundamentals";

    public string Summary =>
        $"Environment: {config.EnvironmentName}\n" +
        $"API Base URL: {config.ApiBaseUrl}";

    public ICommand LogHelloCommand => new Command(() =>
    {
        // This view model doesn't know (or care) *which* logger is used.
        // It only depends on the abstraction (ILoggingService).
        logging.Log("Hello from MainPageViewModel via DI.");
    });
}
