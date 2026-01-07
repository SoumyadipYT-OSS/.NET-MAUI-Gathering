using System.Globalization;

namespace _02_Brushes.Converters;

public sealed class ColorHexToColorConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is null)
            return Colors.Transparent;

        if (value is Color color)
            return color;

        if (value is string str && Color.TryParse(str, out var parsed))
            return parsed;

        return Colors.Transparent;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is Color c)
            return c.ToArgbHex();

        return "#00000000";
    }
}
