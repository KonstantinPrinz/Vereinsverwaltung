using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Data;

namespace Vereinsverwaltung.View.Converter;

public class DateTimeDateTimeOffsetConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value == null)
            return DateTime.Now;
        return new DateTimeOffset(((DateTime)value).ToUniversalTime());
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        if (value == null)
            return DateTime.Now;
        return ((DateTimeOffset)value).DateTime;
    }
}