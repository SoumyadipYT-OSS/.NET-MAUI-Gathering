
using ExpenseApp.Models;
using ExpenseApp.ViewModels;

namespace ExpenseApp.Views;

[QueryProperty(nameof(Expense), nameof(Expense))]
public partial class ExpenseDetailPage : ContentPage
{
	private readonly ExpenseDetailViewModel _vm;

	public Expense Expense 
	{
		get => null;
		set 
		{
			if (value is not null)
				_vm.Load(value);
		}
	}
	public ExpenseDetailPage(ExpenseDetailViewModel vm)
	{
		InitializeComponent();
		_vm = vm;
		BindingContext = _vm;
	}
}