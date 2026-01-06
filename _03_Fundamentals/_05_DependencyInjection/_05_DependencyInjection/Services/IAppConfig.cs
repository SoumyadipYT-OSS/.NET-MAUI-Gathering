namespace _05_DependencyInjection.Services;

public interface IAppConfig
{
    string EnvironmentName { get; }
    string ApiBaseUrl { get; }
}
