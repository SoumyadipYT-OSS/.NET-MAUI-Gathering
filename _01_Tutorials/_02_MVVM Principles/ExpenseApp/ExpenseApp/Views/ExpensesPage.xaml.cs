
using ExpenseApp.Models;
using ExpenseApp.ViewModels;

namespace ExpenseApp.Views;

public partial class ExpensesPage : ContentPage
{
	public ExpensesPage(ExpensesViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

		vm.ExpenseAdded += OnExpenseAdded;
	}


    private async void OnExpenseAdded(object? sender, Expense exp) 
	{
        await Shell.Current.GoToAsync(nameof(ExpenseDetailPage), new Dictionary<string, object>
        {
            { "Expense", exp }
        });
    }

    private async void OnExpenseSelected(object sender, SelectionChangedEventArgs e) 
	{
		if (e.CurrentSelection.FirstOrDefault() is Expense exp) 
		{
			await Shell.Current.GoToAsync(nameof(ExpenseDetailPage), new Dictionary<string, object> {
				{ "Expense", exp }
			});
		}
		if (sender is CollectionView cv)
			cv.SelectedItem = null;
	}
}