namespace _03_Behaviors.Pages;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		BindingContext = new ViewModels.MainPageViewModel();
	}
}