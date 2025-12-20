using System.Globalization;

namespace _01_Overview.Converters;

/// <summary>
/// Multiplies a double value by a factor provided as parameter.
/// Useful for responsive layouts and dynamic sizing.
/// Docs: https://learn.microsoft.com/dotnet/maui/fundamentals/data-binding/converters
/// </summary>
public class DoubleToMultipliedValueConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is double doubleValue && parameter is string multiplierStr)
        {
            if (double.TryParse(multiplierStr, NumberStyles.Any, CultureInfo.InvariantCulture, out double multiplier))
            {
                return doubleValue * multiplier;
            }
        }
        return value ?? 0;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
