

using ExpenseApp.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Input;


namespace ExpenseApp.ViewModels 
{
    public sealed class ExpensesViewModel : INotifyPropertyChanged 
    {
        // Inputs bound from UI
        private string _amountInput = string.Empty;
        private string _categoryInput = string.Empty;

        // Validation messages
        private string _amountError = string.Empty;
        private string _categoryError = string.Empty;

        public ObservableCollection<Expense> Expenses { get; } = new();
        public string AmountInput 
        {
            get => _amountInput;
            set 
            {
                if (SetProperty(ref _amountInput, value)) 
                {
                    ValidateAmount();
                    OnPropertyChanged(nameof(CanAdd));
                    OnPropertyChanged(nameof(Total));
                }
            }
        }

        public string CategoryInput 
        {
            get => _categoryInput;
            set 
            {
                if (SetProperty(ref _categoryInput, value)) 
                {
                    ValidateCategory();
                    OnPropertyChanged(nameof(CanAdd));
                }
            }
        }


// ==============================
        // Error Handling
// ==============================
        public string AmountError 
        {
            get => _amountError;
            private set => SetProperty(ref _amountError, value);
        }

        public string CategoryError 
        {
            get => _categoryError;
            private set => SetProperty(ref _categoryError, value);
        }


//================================
        // Helping methods
//================================

        public decimal Total => Expenses.Sum(e => e.Amount);

        public bool CanAdd => string.IsNullOrEmpty(AmountError) &&
                                string.IsNullOrEmpty(CategoryError) &&
                                !string.IsNullOrWhiteSpace(AmountInput) &&
                                !string.IsNullOrWhiteSpace(CategoryInput);
        public ICommand AddExpenseCommand { get; }
        public ExpensesViewModel() 
        {
            AddExpenseCommand = new Command(
                execute: AddExpense,
                canExecute: () => CanAdd);

            Expenses.CollectionChanged += (_, __) => {
                OnPropertyChanged(nameof(Total));
                ((Command)AddExpenseCommand).ChangeCanExecute();
            };
        }


        //=============================
        // Event Handler for Add Expense
        //=============================

        public event EventHandler<Expense> ExpenseAdded;

        private void AddExpense() 
        {
            if (!decimal.TryParse(AmountInput, NumberStyles.Number, CultureInfo.CurrentCulture, out var amount)) 
            {
                AmountError = "Enter a valid amount.";
                ((Command)AddExpenseCommand).ChangeCanExecute();
                return;
            }

            if (amount <= 0) 
            {
                AmountError = "Amount must be greater than zero.";
                ((Command)AddExpenseCommand).ChangeCanExecute();
                return;
            }

            var category = CategoryInput?.Trim() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(category)) 
            {
                CategoryError = "Category is required.";
                ((Command)AddExpenseCommand).ChangeCanExecute();
                return;
            }

            var exp = new Expense(amount, category);
            Expenses.Add(exp);

            // Nofity navigate to detail
            ExpenseAdded.Invoke(this, exp);

            // Reset inputs
            AmountInput = string.Empty;
            CategoryInput = string.Empty;

            ((Command)AddExpenseCommand).ChangeCanExecute();
        }

        private void ValidateAmount() 
        {
            if (string.IsNullOrWhiteSpace(AmountInput)) 
            {
                AmountError = "Amount is required.";
                ((Command)AddExpenseCommand).ChangeCanExecute();
                return;
            }

            if (!decimal.TryParse(AmountInput, NumberStyles.Number, CultureInfo.CurrentCulture, out var amount)) 
            {
                AmountError = "Enter a valid amount.";
            } else if (amount <= 0) {
                AmountError = "Amount must be greater than zero.";
            } else {
                AmountError = string.Empty;
            }

            ((Command)AddExpenseCommand).ChangeCanExecute();
        }

        private void ValidateCategory() 
        {
            if (string.IsNullOrWhiteSpace(CategoryInput))
                CategoryError = "Category is required";
            else
                CategoryError = string.Empty;

            ((Command)AddExpenseCommand).ChangeCanExecute();
        }

// ============================
        // Event Handlers
// ============================
        public event PropertyChangedEventHandler? PropertyChanged;

        private bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null) 
        {
            if (Equals(storage, value))
                return false;

            storage = value!;
            OnPropertyChanged(propertyName);
            return true;
        }

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            if (propertyName is nameof(CanAdd)) 
            {
                ((Command)AddExpenseCommand).ChangeCanExecute();
            }
        }
    }
}