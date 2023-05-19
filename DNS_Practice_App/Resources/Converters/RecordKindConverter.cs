using System;
using System.Globalization;
using System.Windows.Data;

namespace DNS_Practice_App.Resources.Converters;

public sealed class RecordKindConverter : IValueConverter
{
    public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
    {
        var recordKind = (int)value;

        return recordKind switch {
            0 => "Списание со склада",
            1 => "Поступление на склад",
            _ => $"Неопределено. Номер {recordKind}"
        };
    }

    public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}