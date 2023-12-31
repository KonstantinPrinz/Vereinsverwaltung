using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;

namespace Vereinsverwaltung.View.Converter;

public class DoubleToRedGreenBrushConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is double doubleVal)
        {
            if (doubleVal >= 0)
            {
                return new SolidColorBrush(Colors.LimeGreen);
            }
            return new SolidColorBrush(Colors.Red);
        }

        return DependencyProperty.UnsetValue;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language) => throw new NotImplementedException();
}
