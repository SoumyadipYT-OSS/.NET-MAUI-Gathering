using System.Globalization;

namespace _04_DataBinding.Converters;

// Converts an int to a bool. Used to enable/disable UI based on a numeric source value.
public sealed class IntToBoolConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        => value is int i && i != 0;

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => value is bool b && b ? 1 : 0;
}
