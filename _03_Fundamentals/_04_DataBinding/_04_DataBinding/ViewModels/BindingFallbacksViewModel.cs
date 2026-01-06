namespace _04_DataBinding.ViewModels;

public sealed class BindingFallbacksViewModel : ObservableObject
{
    string? _currentNickname;

    public string? CurrentNickname
    {
        get => _currentNickname;
        set => SetProperty(ref _currentNickname, value);
    }

    public Command ToggleNicknameCommand { get; }

    public BindingFallbacksViewModel()
    {
        CurrentNickname = null;
        ToggleNicknameCommand = new Command(() =>
        {
            CurrentNickname = CurrentNickname is null ? "Maui Learner" : null;
        });
    }
}
