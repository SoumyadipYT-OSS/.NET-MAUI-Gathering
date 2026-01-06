using _04_DataBinding.Models;
using _04_DataBinding.ViewModels;

namespace _04_DataBinding.Views;

public partial class RelativeBindingsPage : ContentPage
{
    public RelativeBindingsPage()
    {
        InitializeComponent();

        // A) Self binding - HeightRequest binds to WidthRequest on the same element
        selfBindingBox.SetBinding(
            BoxView.HeightRequestProperty,
            new Binding("WidthRequest", source: RelativeBindingSource.Self));
    }

    // B) Handle button click in DataTemplate - access the viewmodel command
    private void OnSelectClicked(object? sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is Person person)
        {
            if (BindingContext is RelativeBindingsViewModel vm)
            {
                vm.SelectPersonCommand.Execute(person);
            }
        }
    }
}
