using _01_Overview.ViewModels;

namespace _01_Overview.Pages;

public partial class ThemeSwitcherPage : ContentPage
{
    public ThemeSwitcherPage()
    {
        InitializeComponent();
        BindingContext = new ThemeSwitcherViewModel();
    }
}
