using System.Globalization;

namespace _02_Brushes.Converters;

public sealed class PointFromDoublesConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values.Length < 2)
            return new Point(0, 0);

        var x = values[0] is double dx ? dx : 0;
        var y = values[1] is double dy ? dy : 0;

        return new Point(Clamp01(x), Clamp01(y));
    }

    public object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture)
    {
        if (value is Point p)
            return [p.X, p.Y];

        return [0d, 0d];
    }

    static double Clamp01(double v) => v switch
    {
        < 0 => 0,
        > 1 => 1,
        _ => v
    };
}
