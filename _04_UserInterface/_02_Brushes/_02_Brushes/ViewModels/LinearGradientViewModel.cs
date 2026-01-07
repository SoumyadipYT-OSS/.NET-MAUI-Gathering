using System.Windows.Input;

namespace _02_Brushes.ViewModels;

public sealed class LinearGradientViewModel : BaseViewModel
{
    double _startX;
    double _startY;
    double _endX = 1;
    double _endY = 1;
    double _middleOffset = 0.5;

    public LinearGradientViewModel()
    {
        Title = "LinearGradientBrush";

        SetHorizontalCommand = new Command(() =>
        {
            StartX = 0;
            StartY = 0;
            EndX = 1;
            EndY = 0;
        });

        SetVerticalCommand = new Command(() =>
        {
            StartX = 0;
            StartY = 0;
            EndX = 0;
            EndY = 1;
        });

        SetDiagonalCommand = new Command(() =>
        {
            StartX = 0;
            StartY = 0;
            EndX = 1;
            EndY = 1;
        });

        ReverseCommand = new Command(() =>
        {
            (StartX, EndX) = (EndX, StartX);
            (StartY, EndY) = (EndY, StartY);
        });
    }

    public double StartX { get => _startX; set => SetProperty(ref _startX, Clamp01(value)); }
    public double StartY { get => _startY; set => SetProperty(ref _startY, Clamp01(value)); }
    public double EndX { get => _endX; set => SetProperty(ref _endX, Clamp01(value)); }
    public double EndY { get => _endY; set => SetProperty(ref _endY, Clamp01(value)); }

    public double MiddleOffset { get => _middleOffset; set => SetProperty(ref _middleOffset, Clamp01(value)); }

    public ICommand SetHorizontalCommand { get; }
    public ICommand SetVerticalCommand { get; }
    public ICommand SetDiagonalCommand { get; }
    public ICommand ReverseCommand { get; }

    static double Clamp01(double value) => value switch
    {
        < 0 => 0,
        > 1 => 1,
        _ => value
    };
}
