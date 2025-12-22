using _02_MvvmPattern.ViewModels;

namespace _02_MvvmPattern.Views;

public partial class AddProductPage : ContentPage
{
    public AddProductPage(AddProductViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}