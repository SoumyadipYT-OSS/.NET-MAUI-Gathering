
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExpenseApp.Models;

namespace ExpenseApp.ViewModels;

public partial class ExpenseDetailViewModel : ObservableObject 
{
    private Expense _expense;


    // Exposed properties mapped from underlying Expense
    [ObservableProperty] private decimal amount;
    [ObservableProperty] private string category = string.Empty;
    [ObservableProperty] private string details;
    [ObservableProperty] private DateTime createdAt;

    public bool IsLoaded => _expense is not null;


    public void Load(Expense expense) 
    {
        _expense = expense;
        Amount = expense.Amount;
        Category = expense.Category;
        Details = expense.Details;
        CreatedAt = expense.CreatedAt;
        OnPropertyChanged(nameof(IsLoaded));
    }


    [RelayCommand]
    private void Save() 
    {
        if (_expense is null)
            return;

        _expense.Details = Details;
    }
}
