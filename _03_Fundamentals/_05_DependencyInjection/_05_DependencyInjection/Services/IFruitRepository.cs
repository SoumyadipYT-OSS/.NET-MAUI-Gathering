namespace _05_DependencyInjection.Services;

public interface IFruitRepository
{
    Task<IReadOnlyList<string>> GetFruitsAsync(CancellationToken cancellationToken = default);
}
