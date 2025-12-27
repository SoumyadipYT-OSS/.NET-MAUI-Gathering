using _04_BindingBasics.Models;

namespace _04_BindingBasics.Pages;

public partial class MainPage : ContentPage
{
    readonly PersonModel _person = new();

    public MainPage()
    {
        InitializeComponent();
        BindingContext = _person;
    }
}