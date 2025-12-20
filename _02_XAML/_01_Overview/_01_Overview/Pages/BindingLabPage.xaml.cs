using _01_Overview.ViewModels;

namespace _01_Overview.Pages;

public partial class BindingLabPage : ContentPage
{
    public BindingLabPage()
    {
        InitializeComponent();
        BindingContext = new BindingLabViewModel();
    }
}
