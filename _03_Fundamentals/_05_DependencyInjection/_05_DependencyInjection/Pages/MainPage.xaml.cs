using _05_DependencyInjection.ViewModels;

namespace _05_DependencyInjection.Pages;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private async void OnSingletonClicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(SingletonExamplePage));

    private async void OnTransientClicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(TransientExamplePage));

    private async void OnScopedClicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(ScopedExamplePage));
}
