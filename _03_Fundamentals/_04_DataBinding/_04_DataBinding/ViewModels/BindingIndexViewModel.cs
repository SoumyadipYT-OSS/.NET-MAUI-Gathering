using System.Windows.Input;

namespace _04_DataBinding.ViewModels;

public sealed class BindingIndexViewModel
{
    public ICommand NavigateCommand { get; }

    public BindingIndexViewModel()
    {
        NavigateCommand = new Command<string>(async route =>
        {
            if (string.IsNullOrWhiteSpace(route))
                return;

            // Shell routes are registered in AppShell.
            await Shell.Current.GoToAsync(route);
        });
    }
}
