namespace _01_Overview.Pages;

/// <summary>
/// TriggerClinicPage demonstrates various XAML trigger types.
/// All trigger logic is handled in XAML - this code-behind only initializes the page.
/// </summary>
public partial class TriggerClinicPage : ContentPage
{
    public TriggerClinicPage()
    {
        InitializeComponent();
        BindingContext = new ViewModels.TriggerClinicViewModel();
    }
}