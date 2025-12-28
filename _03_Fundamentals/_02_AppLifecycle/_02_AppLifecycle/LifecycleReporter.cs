namespace _02_AppLifecycle;

public static class LifecycleReporter
{
    public static event Action<string>? EventOccurred;

    public static void Report(string message)
    {
        EventOccurred?.Invoke(message);
    }
}
