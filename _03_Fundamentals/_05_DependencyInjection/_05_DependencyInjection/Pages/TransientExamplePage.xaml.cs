using _05_DependencyInjection.ViewModels;

namespace _05_DependencyInjection.Pages;

public partial class TransientExamplePage : ContentPage
{
    public TransientExamplePage(TransientExampleViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private async void OnBackClicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync("..");
}
