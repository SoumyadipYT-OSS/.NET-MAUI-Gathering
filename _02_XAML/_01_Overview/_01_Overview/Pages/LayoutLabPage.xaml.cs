using _01_Overview.ViewModels;

namespace _01_Overview.Pages;

public partial class LayoutLabPage : ContentPage
{
    public LayoutLabPage()
    {
        InitializeComponent();
        BindingContext = new LayoutLabViewModel();
    }
}
