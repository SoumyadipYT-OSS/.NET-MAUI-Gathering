using _01_Animation.ViewModels;

namespace _01_Animation.Views;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }

    private async void OnDemoTapped(object? sender, TappedEventArgs e)
    {
        if (e.Parameter is not string route || string.IsNullOrWhiteSpace(route))
            return;

        await Shell.Current.GoToAsync(route);
    }
}
