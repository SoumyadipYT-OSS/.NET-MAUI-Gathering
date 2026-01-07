using _02_Brushes.ViewModels;

namespace _02_Brushes.Views;

public partial class SolidColorBrushPage : ContentPage
{
    public SolidColorBrushPage(SolidColorBrushViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
