using _03_DataBindMvvm.Helpers;
using _03_DataBindMvvm.ViewModels;

namespace _03_DataBindMvvm.Pages;

public partial class MainPage : ContentPage
{
    public MainPage() : this(ServiceHelper.GetRequiredService<MainViewModel>())
    {
    }

    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}