namespace _04_DataBinding.ViewModels;

public sealed class BindingModesViewModel : ObservableObject
{
    double _angle;
    string _draftText = "Edit me";
    string _savedText = "(not saved yet)";

    public double Angle
    {
        get => _angle;
        set => SetProperty(ref _angle, value);
    }

    public string DraftText
    {
        get => _draftText;
        set => SetProperty(ref _draftText, value);
    }

    public string SavedText
    {
        get => _savedText;
        private set => SetProperty(ref _savedText, value);
    }

    public Command SaveCommand { get; }

    public BindingModesViewModel()
    {
        SaveCommand = new Command(() => SavedText = DraftText);
    }
}
