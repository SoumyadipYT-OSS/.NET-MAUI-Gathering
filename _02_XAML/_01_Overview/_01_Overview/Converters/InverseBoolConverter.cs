using System.Globalization;

namespace _01_Overview.Converters;

/// <summary>
/// Converts a boolean value to its inverse. Useful for IsEnabled/IsVisible bindings.
/// Docs: https://learn.microsoft.com/dotnet/maui/fundamentals/data-binding/converters
/// </summary>
public class InverseBoolConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is bool boolValue)
            return !boolValue;
        return value;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is bool boolValue)
            return !boolValue;
        return value;
    }
}
