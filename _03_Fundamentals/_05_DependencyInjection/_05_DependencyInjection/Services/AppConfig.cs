namespace _05_DependencyInjection.Services;

public sealed class AppConfig : IAppConfig
{
    public string EnvironmentName { get; init; } = "Development";
    public string ApiBaseUrl { get; init; } = "https://example.invalid/api";
}
