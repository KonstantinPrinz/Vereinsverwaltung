using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;

namespace Vereinsverwaltung.ViewModel;

public interface IDialogService
{
    public XamlRoot XamlRoot { get; set; }
    public Task<bool> ShowAsync(ViewModelBase dialogViewModel);
}
