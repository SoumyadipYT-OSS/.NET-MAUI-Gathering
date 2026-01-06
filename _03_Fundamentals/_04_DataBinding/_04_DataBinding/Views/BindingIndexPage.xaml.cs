using _04_DataBinding.ViewModels;

namespace _04_DataBinding.Views;

public partial class BindingIndexPage : ContentPage
{
    public BindingIndexPage(BindingIndexViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
