namespace _04_DataBinding.ViewModels;

public sealed class CompiledBindingsViewModel : ObservableObject
{
    string _name = "MAUI";
    double _progress = 25;

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public double Progress
    {
        get => _progress;
        set
        {
            if (SetProperty(ref _progress, value))
                OnPropertyChanged(nameof(ProgressNormalized));
        }
    }

    // ProgressBar.Progress expects 0..1, so we expose a derived property.
    public double ProgressNormalized => Math.Clamp(Progress / 100.0, 0, 1);

    public IList<string> Items { get; } = new List<string>
    {
        "First item",
        "Second item",
        "Third item"
    };
}
