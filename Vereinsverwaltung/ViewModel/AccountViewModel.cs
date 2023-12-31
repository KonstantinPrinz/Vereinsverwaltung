using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vereinsverwaltung.ViewModel;

public partial class AccountViewModel : ViewModelBase
{
    [ObservableProperty]
    private string iban;
    [ObservableProperty]
    private double balance;
    [ObservableProperty]
    private ObservableCollection<Entry> entries;

    [ObservableProperty]
    private DateTime beginEntryFilter = DateTime.Now.AddDays(-14);
    [ObservableProperty]
    private DateTime endEntryFilter = DateTime.Now;   

    public AccountViewModel(DataAccessor dataAccessor, ResourceLoader resourceLoader) : base(dataAccessor, resourceLoader)
    {
    }

    [RelayCommand]
    private async Task LoadAccount()
    {
        var account = await dataAccessor.Account.Value;

        Balance = account.Balance;
        Iban = account.IBAN;
        Entries = new ObservableCollection<Entry>(account.Entries.OrderByDescending(e => e.TimeStamp));
        
        // initial call to filter entries with the default dates
        await DateFilterChanged();
    }

    [RelayCommand]
    private async Task DateFilterChanged()
    {
        Entries.Clear();

        var account = await dataAccessor.Account.Value;
        
        Entries = new ObservableCollection<Entry>(account.GetEntriesInDateRange(BeginEntryFilter, EndEntryFilter).OrderByDescending(e => e.TimeStamp));
    }
}
