namespace _05_DependencyInjection.Services;

public sealed class OperationId : IOperationId
{
    public Guid Id { get; } = Guid.NewGuid();
}
