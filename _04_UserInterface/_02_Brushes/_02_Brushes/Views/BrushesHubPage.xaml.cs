using _02_Brushes.ViewModels;

namespace _02_Brushes.Views;

public partial class BrushesHubPage : ContentPage
{
    public BrushesHubPage(BrushesHubViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
