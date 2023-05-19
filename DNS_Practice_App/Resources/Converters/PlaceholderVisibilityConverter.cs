using System;
using System.Globalization;
using System.Windows.Data;

namespace DNS_Practice_App.Resources.Converters;

public sealed class PlaceholderVisibilityConverter : IValueConverter
{
    public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
    {
        return string.IsNullOrWhiteSpace(value.ToString());
    }

    public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}