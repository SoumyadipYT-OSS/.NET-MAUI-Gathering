using _05_DependencyInjection.ViewModels;

namespace _05_DependencyInjection.Pages;

public partial class SingletonExamplePage : ContentPage
{
    private readonly SingletonExampleViewModel _viewModel;

    public SingletonExamplePage(SingletonExampleViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = viewModel;
    }

    private void OnLogClicked(object sender, EventArgs e) => _viewModel.Log();

    private async void OnBackClicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync("..");
}
