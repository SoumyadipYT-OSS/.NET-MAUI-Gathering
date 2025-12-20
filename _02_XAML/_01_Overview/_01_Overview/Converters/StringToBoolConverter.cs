using System.Globalization;

namespace _01_Overview.Converters;

/// <summary>
/// Converts a string to a boolean indicating whether it has content.
/// Returns true if string is not null/empty/whitespace.
/// Docs: https://learn.microsoft.com/dotnet/maui/fundamentals/data-binding/converters
/// </summary>
public class StringToBoolConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return !string.IsNullOrWhiteSpace(value?.ToString());
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
