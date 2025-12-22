using _02_MvvmPattern.ViewModels;

namespace _02_MvvmPattern.Views;

public partial class EditProductPage : ContentPage
{
    public EditProductPage(EditProductViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
