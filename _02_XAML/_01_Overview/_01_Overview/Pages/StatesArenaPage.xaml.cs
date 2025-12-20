using _01_Overview.ViewModels;

namespace _01_Overview.Pages;

public partial class StatesArenaPage : ContentPage
{
    public StatesArenaPage()
    {
        InitializeComponent();
        BindingContext = new StatesArenaViewModel();
    }
}
