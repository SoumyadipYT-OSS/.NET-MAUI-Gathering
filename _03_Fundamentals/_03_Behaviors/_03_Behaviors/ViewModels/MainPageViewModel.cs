using System.Windows.Input;

namespace _03_Behaviors.ViewModels;

// Simple ViewModel to demonstrate using a built-in behavior (EventToCommandBehavior)
// to route UI events to commands.
public sealed class MainPageViewModel : BindableObject
{
    string? _ageText;
    string? _status;

    public string? AgeText
    {
        get => _ageText;
        set
        {
            _ageText = value;
            OnPropertyChanged();
        }
    }

    public string? Status
    {
        get => _status;
        set
        {
            _status = value;
            OnPropertyChanged();
        }
    }

    public ICommand SubmitCommand { get; }

    public MainPageViewModel()
    {
        SubmitCommand = new Command(OnSubmit);
        Status = "Enter a number and tap Submit.";
    }

    void OnSubmit()
    {
        Status = string.IsNullOrWhiteSpace(AgeText)
            ? "Nothing to submit yet."
            : $"Submitted value: {AgeText}";
    }
}
