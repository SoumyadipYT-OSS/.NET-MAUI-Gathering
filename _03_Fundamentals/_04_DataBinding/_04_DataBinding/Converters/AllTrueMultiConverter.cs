using System.Globalization;

namespace _04_DataBinding.Converters;

// A MultiBinding converter that returns true only if every bound value is true.
public sealed class AllTrueMultiConverter : IMultiValueConverter
{
    public object Convert(object[]? values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values is null || !targetType.IsAssignableFrom(typeof(bool)))
            return false;

        foreach (var value in values)
        {
            if (value is not bool b)
                return false;

            if (!b)
                return false;
        }

        return true;
    }

    public object[]? ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture)
    {
        // Keep the tutorial simple: we don't support two-way conversion here.
        return null;
    }
}
