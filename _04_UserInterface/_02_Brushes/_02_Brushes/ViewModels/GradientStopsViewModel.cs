namespace _02_Brushes.ViewModels;

public sealed class GradientStopsViewModel : BaseViewModel
{
    double _stop2Offset = 0.5;

    public GradientStopsViewModel()
    {
        Title = "Gradient stops";
    }

    public double Stop2Offset
    {
        get => _stop2Offset;
        set => SetProperty(ref _stop2Offset, Clamp01(value));
    }

    static double Clamp01(double value) => value switch
    {
        < 0 => 0,
        > 1 => 1,
        _ => value
    };
}
