namespace _01_Overview.ViewModels;

/// <summary>
/// ViewModel for TriggerClinic page demonstrating XAML triggers.
/// Shows PropertyTrigger, DataTrigger, MultiTrigger, and EventTrigger.
/// Docs: https://learn.microsoft.com/dotnet/maui/fundamentals/triggers
/// </summary>
public class TriggerClinicViewModel : BaseViewModel
{
    private string _inputText = "";
    private string _email = "";
    private string _password = "";
    private bool _termsAccepted;
    private bool _isSubscribed;
    private int _quantity = 1;
    private bool _isPremiumUser;

    public string InputText
    {
        get => _inputText;
        set
        {
            if (SetProperty(ref _inputText, value))
            {
                OnPropertyChanged(nameof(HasInputText));
                OnPropertyChanged(nameof(CanSave));
                OnPropertyChanged(nameof(CharacterCount));
            }
        }
    }

    public string Email
    {
        get => _email;
        set
        {
            if (SetProperty(ref _email, value))
            {
                OnPropertyChanged(nameof(IsValidEmail));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }
    }

    public string Password
    {
        get => _password;
        set
        {
            if (SetProperty(ref _password, value))
            {
                OnPropertyChanged(nameof(IsStrongPassword));
                OnPropertyChanged(nameof(PasswordStrength));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }
    }

    public bool TermsAccepted
    {
        get => _termsAccepted;
        set
        {
            if (SetProperty(ref _termsAccepted, value))
            {
                OnPropertyChanged(nameof(CanSubmit));
            }
        }
    }

    public bool IsSubscribed
    {
        get => _isSubscribed;
        set => SetProperty(ref _isSubscribed, value);
    }

    public int Quantity
    {
        get => _quantity;
        set
        {
            if (SetProperty(ref _quantity, Math.Max(1, value)))
            {
                OnPropertyChanged(nameof(TotalPrice));
                OnPropertyChanged(nameof(HasDiscount));
            }
        }
    }

    public bool IsPremiumUser
    {
        get => _isPremiumUser;
        set
        {
            if (SetProperty(ref _isPremiumUser, value))
            {
                OnPropertyChanged(nameof(TotalPrice));
                OnPropertyChanged(nameof(HasDiscount));
            }
        }
    }

    // Computed properties for triggers
    public bool HasInputText => !string.IsNullOrWhiteSpace(InputText);
    public bool CanSave => HasInputText && InputText.Length >= 3;
    public int CharacterCount => InputText?.Length ?? 0;

    public bool IsValidEmail => !string.IsNullOrWhiteSpace(Email) && 
                                 Email.Contains('@') && 
                                 Email.Contains('.');

    public bool IsStrongPassword => Password?.Length >= 8;
    
    public string PasswordStrength => Password?.Length switch
    {
        null or 0 => "Empty",
        < 4 => "Weak",
        < 8 => "Medium",
        _ => "Strong"
    };

    public bool CanSubmit => IsValidEmail && IsStrongPassword && TermsAccepted;

    public decimal TotalPrice => Quantity * 9.99m * (IsPremiumUser ? 0.9m : 1m);
    public bool HasDiscount => Quantity >= 5 || IsPremiumUser;
}
