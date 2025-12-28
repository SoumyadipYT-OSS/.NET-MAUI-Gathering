using System.Collections.ObjectModel;
using _02_AppLifecycle;

namespace _02_AppLifecycle.Views;

public partial class MainPage : ContentPage
{
    public ObservableCollection<string> LogEntries { get; } = new();

    bool _windowEventsHooked;

    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;

        Loaded += OnLoaded;
        Unloaded += OnUnloaded;

        Log("Page constructed");
    }

    void OnLoaded(object? sender, EventArgs e)
    {
        LifecycleReporter.EventOccurred += OnLifecycleEvent;

        if (Application.Current is Application app)
        {
            app.RequestedThemeChanged += OnThemeChanged;
        }

        if (!_windowEventsHooked && Window is Window window)
        {
            window.Created += OnWindowCreated;
            window.Activated += OnWindowActivated;
            window.Deactivated += OnWindowDeactivated;
            window.Stopped += OnWindowStopped;
            window.Resumed += OnWindowResumed;
            _windowEventsHooked = true;
        }

        Log("Page loaded");
    }

    void OnUnloaded(object? sender, EventArgs e)
    {
        LifecycleReporter.EventOccurred -= OnLifecycleEvent;

        if (Application.Current is Application app)
        {
            app.RequestedThemeChanged -= OnThemeChanged;
        }

        if (_windowEventsHooked && Window is Window window)
        {
            window.Created -= OnWindowCreated;
            window.Activated -= OnWindowActivated;
            window.Deactivated -= OnWindowDeactivated;
            window.Stopped -= OnWindowStopped;
            window.Resumed -= OnWindowResumed;
            _windowEventsHooked = false;
        }

        Log("Page unloaded");
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Log("OnAppearing");
    }

    protected override void OnDisappearing()
    {
        Log("OnDisappearing");
        base.OnDisappearing();
    }

    void OnAddTestEventClicked(object sender, EventArgs e) => Log("Manual test event");

    void OnClearClicked(object sender, EventArgs e) => LogEntries.Clear();

    void OnLifecycleEvent(string message) => Log(message);

    void OnThemeChanged(object? sender, AppThemeChangedEventArgs e) => Log($"RequestedThemeChanged -> {e.RequestedTheme}");

    void OnWindowCreated(object? sender, EventArgs e) => Log("Window Created");

    void OnWindowActivated(object? sender, EventArgs e) => Log("Window Activated (foreground)");

    void OnWindowDeactivated(object? sender, EventArgs e) => Log("Window Deactivated (background)");

    void OnWindowStopped(object? sender, EventArgs e) => Log("Window Stopped");

    void OnWindowResumed(object? sender, EventArgs e) => Log("Window Resumed");

    void Log(string message)
    {
        var timestamp = DateTime.Now.ToString("HH:mm:ss");
        LogEntries.Insert(0, $"[{timestamp}] {message}");
    }
}