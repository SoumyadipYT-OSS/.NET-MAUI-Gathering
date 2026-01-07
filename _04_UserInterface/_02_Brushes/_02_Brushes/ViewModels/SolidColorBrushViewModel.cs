using System.Windows.Input;

namespace _02_Brushes.ViewModels;

public sealed class SolidColorBrushViewModel : BaseViewModel
{
    string _hexColor = "#FF9988";

    public SolidColorBrushViewModel()
    {
        Title = "SolidColorBrush";

        SetSalmonCommand = new Command(() => HexColor = "#FF9988");
        SetIndigoCommand = new Command(() => HexColor = "#4B0082");
        SetTransparentRedCommand = new Command(() => HexColor = "#80FF0000");
    }

    // Accepts #RRGGBB or #AARRGGBB. The converter will parse it to a Color.
    public string HexColor
    {
        get => _hexColor;
        set => SetProperty(ref _hexColor, value?.Trim() ?? string.Empty);
    }

    public ICommand SetSalmonCommand { get; }
    public ICommand SetIndigoCommand { get; }
    public ICommand SetTransparentRedCommand { get; }
}
