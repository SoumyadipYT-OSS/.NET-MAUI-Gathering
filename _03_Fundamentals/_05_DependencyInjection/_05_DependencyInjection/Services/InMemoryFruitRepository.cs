namespace _05_DependencyInjection.Services;

public sealed class InMemoryFruitRepository(IClock clock, ILoggingService logging) : IFruitRepository
{
    public async Task<IReadOnlyList<string>> GetFruitsAsync(CancellationToken cancellationToken = default)
    {
        // Pretend we are doing I/O to mimic a real data access dependency.
        await Task.Delay(TimeSpan.FromMilliseconds(250), cancellationToken);

        logging.Log($"Loaded fruit list at {clock.Now:O}");

        return new[] { "Apple", "Banana", "Cherry", "Mango" };
    }
}
