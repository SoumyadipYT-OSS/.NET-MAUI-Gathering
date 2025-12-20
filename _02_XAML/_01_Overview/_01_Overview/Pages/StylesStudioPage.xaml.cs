using _01_Overview.ViewModels;

namespace _01_Overview.Pages;

public partial class StylesStudioPage : ContentPage
{
    public StylesStudioPage()
    {
        InitializeComponent();
        BindingContext = new StylesStudioViewModel();
    }
}
