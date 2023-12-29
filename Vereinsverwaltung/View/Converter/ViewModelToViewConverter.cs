using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Markup;
using Microsoft.UI.Xaml;

namespace Vereinsverwaltung.View.Converter;
public class ViewModelToViewConverter : MarkupExtension, IValueConverter
{
    private static readonly Dictionary<Type, Type> pairs = new()
        {
            {typeof(MainWindowViewModel),typeof(MainWindow)},
            {typeof(DashboardViewModel),typeof(DashboardView)},
            {typeof(MemberViewModel),typeof(MemberView)},
        };

    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value == null)
            return DependencyProperty.UnsetValue;

        pairs.TryGetValue(value.GetType(), out var viewType);
        FrameworkElement view = (FrameworkElement)App.ServiceProvider.GetRequiredService(viewType);
        view.DataContext = value;
        return view;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        if (Debugger.IsAttached)
            Debugger.Break();
        return DependencyProperty.UnsetValue;
    }
}