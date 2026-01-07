namespace _02_Brushes.ViewModels;

public sealed class RadialGradientViewModel : BaseViewModel
{
    double _centerX = 0.5;
    double _centerY = 0.5;
    double _radius = 0.5;
    double _innerOffset = 0.1;

    public RadialGradientViewModel()
    {
        Title = "RadialGradientBrush";
    }

    public double CenterX { get => _centerX; set => SetProperty(ref _centerX, Clamp01(value)); }
    public double CenterY { get => _centerY; set => SetProperty(ref _centerY, Clamp01(value)); }

    public double Radius
    {
        get => _radius;
        set => SetProperty(ref _radius, Clamp01(value));
    }

    public double InnerOffset
    {
        get => _innerOffset;
        set => SetProperty(ref _innerOffset, Clamp01(value));
    }

    static double Clamp01(double value) => value switch
    {
        < 0 => 0,
        > 1 => 1,
        _ => value
    };
}
