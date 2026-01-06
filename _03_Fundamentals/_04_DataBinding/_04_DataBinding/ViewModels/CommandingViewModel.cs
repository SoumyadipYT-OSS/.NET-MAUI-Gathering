namespace _04_DataBinding.ViewModels;

public sealed class CommandingViewModel : ObservableObject
{
    int _count;

    public int Count
    {
        get => _count;
        private set
        {
            if (SetProperty(ref _count, value))
                RefreshCanExecutes();
        }
    }

    public Command IncrementCommand { get; }
    public Command DecrementCommand { get; }
    public Command<string> SetCountCommand { get; }

    public CommandingViewModel()
    {
        IncrementCommand = new Command(() => Count++);

        DecrementCommand = new Command(
            execute: () => Count--,
            canExecute: () => Count > 0);

        // CommandParameter from XAML is always a string, so we parse it here
        SetCountCommand = new Command<string>(
            execute: s =>
            {
                if (int.TryParse(s, out var v))
                    Count = v;
            },
            canExecute: _ => true);
    }

    void RefreshCanExecutes()
        => DecrementCommand.ChangeCanExecute();
}
