using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Vereinsverwaltung.ViewModel;

public class DialogService : IDialogService
{
    public XamlRoot XamlRoot { get; set; }

    public async Task<bool> ShowAsync(ViewModelBase dialogViewModel)
    {
        var converter = App.ServiceProvider.GetRequiredService<ViewModelToViewConverter>();
        var dialog = converter.Convert(dialogViewModel, null, null, string.Empty);

        if (dialog is not ContentDialog dlg)
        {
            return false;
        }

        dlg.XamlRoot = XamlRoot;
        return await dlg.ShowAsync() == ContentDialogResult.Primary;
    }
}
