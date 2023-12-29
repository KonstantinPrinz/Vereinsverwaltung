using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vereinsverwaltung.ViewModel;

public partial class MemberViewModel : ViewModelBase
{
    [ObservableProperty]
    private IEnumerable<Member> members;

    public MemberViewModel(DataAccessor dataAccessor, 
        ResourceLoader resourceLoader) : base(dataAccessor, resourceLoader)
    {

    }

    [RelayCommand]
    private async Task LoadMembers()
    {
        Members = await dataAccessor.Members.Value;
    }
}
