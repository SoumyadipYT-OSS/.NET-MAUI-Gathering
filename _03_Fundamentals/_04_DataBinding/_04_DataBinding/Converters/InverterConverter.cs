using System.Globalization;

namespace _04_DataBinding.Converters;

// Inverts a bool. Handy for demonstrations and for MultiBinding scenarios.
public sealed class InverterConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        => value is bool b && !b;

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => value is bool b && !b;
}
