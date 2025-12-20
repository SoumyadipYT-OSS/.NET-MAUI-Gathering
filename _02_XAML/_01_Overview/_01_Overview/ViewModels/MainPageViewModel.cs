using System.Windows.Input;

namespace _01_Overview.ViewModels;

/// <summary>
/// ViewModel for MainPage - the home/hub page of the XAML Overview learning project.
/// Provides navigation commands to all module pages.
/// </summary>
public class MainPageViewModel : BaseViewModel
{
    public MainPageViewModel()
    {
        NavigateToLayoutLabCommand = new Command(async () => await Shell.Current.GoToAsync("LayoutLab"));
        NavigateToBindingLabCommand = new Command(async () => await Shell.Current.GoToAsync("BindingLab"));
        NavigateToStylesStudioCommand = new Command(async () => await Shell.Current.GoToAsync("StylesStudio"));
        NavigateToTemplateForgeCommand = new Command(async () => await Shell.Current.GoToAsync("TemplateForge"));
        NavigateToTriggerClinicCommand = new Command(async () => await Shell.Current.GoToAsync("TriggerClinic"));
        NavigateToStatesArenaCommand = new Command(async () => await Shell.Current.GoToAsync("StatesArena"));
        NavigateToThemeSwitcherCommand = new Command(async () => await Shell.Current.GoToAsync("ThemeSwitcher"));
        
        // Example of navigation with query parameters
        NavigateWithParameterCommand = new Command<string>(async (param) => 
            await Shell.Current.GoToAsync($"BindingLab?message={Uri.EscapeDataString(param ?? "Hello from MainPage")}"));
    }

    public string WelcomeMessage => "XAML Fundamentals Learning Project";
    public string Description => "Explore comprehensive XAML concepts with hands-on examples";

    public ICommand NavigateToLayoutLabCommand { get; }
    public ICommand NavigateToBindingLabCommand { get; }
    public ICommand NavigateToStylesStudioCommand { get; }
    public ICommand NavigateToTemplateForgeCommand { get; }
    public ICommand NavigateToTriggerClinicCommand { get; }
    public ICommand NavigateToStatesArenaCommand { get; }
    public ICommand NavigateToThemeSwitcherCommand { get; }
    public ICommand NavigateWithParameterCommand { get; }
}
