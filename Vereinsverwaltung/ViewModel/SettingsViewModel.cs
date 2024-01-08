using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vereinsverwaltung.ViewModel;
public partial class SettingsViewModel : ViewModelBase
{
    [ObservableProperty]
    private string iban;

    [ObservableProperty]
    private ObservableCollection<Member> members;

    public SettingsViewModel(DataAccessor dataAccessor, ResourceLoader resourceLoader) : base(dataAccessor, resourceLoader)
    {
    }

    [RelayCommand]
    private async Task LoadSettings()
    {
        var account = await dataAccessor.Account.Value;
        Iban = account.IBAN;

        Members = new ObservableCollection<Member>(await dataAccessor.Members.Value);
    }

    [RelayCommand]
    private async Task SetSettings()
    {
        var account = await dataAccessor.Account.Value;
        account.IBAN = Iban;
        await dataAccessor.SetAccount(account);
    }
}
