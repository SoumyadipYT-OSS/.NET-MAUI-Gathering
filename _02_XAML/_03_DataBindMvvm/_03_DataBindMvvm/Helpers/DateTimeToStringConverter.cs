using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace _03_DataBindMvvm.Helpers;

/// <summary>
/// Converts a <see cref="DateTime"/> value to a formatted string for display.
/// Keeps formatting concerns out of viewmodels.
/// </summary>
public sealed class DateTimeToStringConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not DateTime dateTime)
        {
            return string.Empty;
        }

        var format = parameter as string;
        return string.IsNullOrWhiteSpace(format)
            ? dateTime.ToString(culture)
            : dateTime.ToString(format, culture);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        // One-way converter only: UI -> ViewModel conversion is not required here.
        return null;
    }
}
