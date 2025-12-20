using System.Windows.Input;

namespace _01_Overview.ViewModels;

/// <summary>
/// ViewModel for ThemeSwitcher page demonstrating Light/Dark theme switching.
/// Uses DynamicResource for runtime theme updates and system theme responsiveness.
/// Docs: https://learn.microsoft.com/dotnet/maui/user-interface/theming
/// </summary>
public class ThemeSwitcherViewModel : BaseViewModel
{
    private string _currentTheme = "System";
    private bool _isSystemTheme = true;

    public ThemeSwitcherViewModel()
    {
        SetLightThemeCommand = new Command(() => SetTheme(AppTheme.Light));
        SetDarkThemeCommand = new Command(() => SetTheme(AppTheme.Dark));
        SetSystemThemeCommand = new Command(() => SetTheme(AppTheme.Unspecified));
        ToggleThemeCommand = new Command(ToggleTheme);

        // Initialize current theme display
        UpdateCurrentThemeDisplay();
    }

    public string CurrentTheme
    {
        get => _currentTheme;
        set => SetProperty(ref _currentTheme, value);
    }

    public bool IsSystemTheme
    {
        get => _isSystemTheme;
        set => SetProperty(ref _isSystemTheme, value);
    }

    public string ActualTheme => Application.Current?.RequestedTheme.ToString() ?? "Unknown";

    public ICommand SetLightThemeCommand { get; }
    public ICommand SetDarkThemeCommand { get; }
    public ICommand SetSystemThemeCommand { get; }
    public ICommand ToggleThemeCommand { get; }

    private void SetTheme(AppTheme theme)
    {
        if (Application.Current is not null)
        {
            Application.Current.UserAppTheme = theme;
            IsSystemTheme = theme == AppTheme.Unspecified;
            UpdateCurrentThemeDisplay();
        }
    }

    private void ToggleTheme()
    {
        if (Application.Current is null) return;

        var currentTheme = Application.Current.UserAppTheme;
        var newTheme = currentTheme switch
        {
            AppTheme.Light => AppTheme.Dark,
            AppTheme.Dark => AppTheme.Light,
            _ => Application.Current.RequestedTheme == AppTheme.Light ? AppTheme.Dark : AppTheme.Light
        };

        SetTheme(newTheme);
    }

    private void UpdateCurrentThemeDisplay()
    {
        if (Application.Current is null) return;

        CurrentTheme = Application.Current.UserAppTheme switch
        {
            AppTheme.Light => "Light",
            AppTheme.Dark => "Dark",
            _ => $"System ({Application.Current.RequestedTheme})"
        };

        OnPropertyChanged(nameof(ActualTheme));
    }

    public string ThemeExplanation => @"Theme switching in MAUI uses:
• DynamicResource: Updates UI at runtime when resource changes
• StaticResource: Resolved once at load time, doesn't update
• AppThemeBinding: Automatically switches based on system theme
• UserAppTheme: Programmatically override system theme

Set UserAppTheme to Unspecified to follow system theme.";
}
