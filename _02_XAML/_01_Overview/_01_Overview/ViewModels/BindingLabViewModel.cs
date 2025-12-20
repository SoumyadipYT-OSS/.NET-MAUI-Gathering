using System.Windows.Input;

namespace _01_Overview.ViewModels;

/// <summary>
/// ViewModel for BindingLab page demonstrating data binding concepts.
/// Shows OneWay, TwoWay, OneTime binding modes and converters.
/// Supports [QueryProperty] for receiving navigation parameters.
/// Docs: https://learn.microsoft.com/dotnet/maui/fundamentals/data-binding/binding-mode
/// </summary>
[QueryProperty(nameof(Message), "message")]
public class BindingLabViewModel : BaseViewModel
{
    private string _message = "Default Message";
    private string _userName = "";
    private double _sliderValue = 50;
    private bool _isChecked;
    private int _counter;
    private DateTime _selectedDate = DateTime.Today;
    private string _formattedOutput = "";

    public BindingLabViewModel()
    {
        IncrementCommand = new Command(() => Counter++);
        DecrementCommand = new Command(() => Counter--, () => Counter > 0);
        UpdateFormattedOutputCommand = new Command(UpdateFormattedOutput);
    }

    /// <summary>
    /// Receives message from navigation query parameter.
    /// Example: GoToAsync("BindingLab?message=Hello")
    /// </summary>
    public string Message
    {
        get => _message;
        set => SetProperty(ref _message, Uri.UnescapeDataString(value ?? ""));
    }

    public string UserName
    {
        get => _userName;
        set
        {
            if (SetProperty(ref _userName, value))
            {
                OnPropertyChanged(nameof(Greeting));
                OnPropertyChanged(nameof(HasUserName));
            }
        }
    }

    public string Greeting => string.IsNullOrWhiteSpace(UserName) 
        ? "Enter your name above" 
        : $"Hello, {UserName}!";

    public bool HasUserName => !string.IsNullOrWhiteSpace(UserName);

    public double SliderValue
    {
        get => _sliderValue;
        set
        {
            if (SetProperty(ref _sliderValue, value))
            {
                OnPropertyChanged(nameof(SliderDisplayValue));
                OnPropertyChanged(nameof(SliderPercentage));
            }
        }
    }

    public string SliderDisplayValue => $"Value: {SliderValue:F1}";
    public string SliderPercentage => $"{SliderValue:F0}%";

    public bool IsChecked
    {
        get => _isChecked;
        set
        {
            if (SetProperty(ref _isChecked, value))
            {
                OnPropertyChanged(nameof(CheckboxStatus));
            }
        }
    }

    public string CheckboxStatus => IsChecked ? "Enabled" : "Disabled";

    public int Counter
    {
        get => _counter;
        set
        {
            if (SetProperty(ref _counter, value))
            {
                ((Command)DecrementCommand).ChangeCanExecute();
            }
        }
    }

    public DateTime SelectedDate
    {
        get => _selectedDate;
        set
        {
            if (SetProperty(ref _selectedDate, value))
            {
                OnPropertyChanged(nameof(FormattedDate));
                OnPropertyChanged(nameof(DaysUntilDate));
            }
        }
    }

    public string FormattedDate => SelectedDate.ToString("MMMM dd, yyyy");
    public string DaysUntilDate
    {
        get
        {
            var days = (SelectedDate - DateTime.Today).Days;
            return days switch
            {
                0 => "Today",
                1 => "Tomorrow",
                -1 => "Yesterday",
                > 0 => $"{days} days from now",
                _ => $"{Math.Abs(days)} days ago"
            };
        }
    }

    public string FormattedOutput
    {
        get => _formattedOutput;
        set => SetProperty(ref _formattedOutput, value);
    }

    public ICommand IncrementCommand { get; }
    public ICommand DecrementCommand { get; }
    public ICommand UpdateFormattedOutputCommand { get; }

    private void UpdateFormattedOutput()
    {
        FormattedOutput = $"User: {UserName}\nSlider: {SliderValue:F1}\nChecked: {IsChecked}\nDate: {FormattedDate}";
    }

    // Add these properties to BindingLabViewModel

    public string? NullableProperty { get; set; } = null;

    public string InitialTimestamp { get; } = DateTime.Now.ToString("HH:mm:ss.fff");
}
