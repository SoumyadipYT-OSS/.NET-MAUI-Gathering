namespace _05_DependencyInjection.Services;

public interface IClock
{
    DateTimeOffset Now { get; }
}
