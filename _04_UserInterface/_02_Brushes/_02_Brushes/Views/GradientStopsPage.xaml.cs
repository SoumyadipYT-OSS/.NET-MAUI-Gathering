using _02_Brushes.ViewModels;

namespace _02_Brushes.Views;

public partial class GradientStopsPage : ContentPage
{
    public GradientStopsPage(GradientStopsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
