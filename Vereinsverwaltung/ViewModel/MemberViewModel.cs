using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;

namespace Vereinsverwaltung.ViewModel;

public partial class MemberViewModel : ViewModelBase
{
    public bool IsMemberSelected => SelectedMember != null;

    [ObservableProperty]
    private ObservableCollection<Member> members;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsMemberSelected))]
    private Member selectedMember;

    private readonly IDialogService dialogService;

    public MemberViewModel(DataAccessor dataAccessor, 
        ResourceLoader resourceLoader, IDialogService dialogService) : base(dataAccessor, resourceLoader)
    {
        this.dialogService = dialogService;
    }

    [RelayCommand]
    private async Task LoadMembers()
    {
        Members = new ObservableCollection<Member>(await dataAccessor.Members.Value);
    }

    [RelayCommand]
    private async Task CreateMember()
    {
        var dialogViewModel = App.ServiceProvider.GetRequiredService<CreateMemberViewModel>();

        if (await dialogService.ShowAsync(dialogViewModel))
        {
            var member = new Member()
            {
                Id = Guid.NewGuid(),
                BirthDate = dialogViewModel.BirthDate,
                FirstName = dialogViewModel.FirstName,
                LastName = dialogViewModel.LastName,
                Contribution = dialogViewModel.Contribution,
                EmploymentType = dialogViewModel.Employment,
                IBAN = dialogViewModel.Iban,
            };

            var members = await dataAccessor.Members.Value;
            members.Add(member);
            Members.Add(member);

            await dataAccessor.SetMembers(members);
        }
    }

    [RelayCommand]
    private async Task DeleteMember()
    {
        if (await dialogService.ShowAsync(App.ServiceProvider.GetRequiredService<ConfirmActionViewModel>()))
        {
            if (SelectedMember != null)
            {
                var members = await dataAccessor.Members.Value;
                var memberToDelete = members.Where(m => m.Id == SelectedMember.Id).FirstOrDefault();
                
                if (memberToDelete != null)
                {
                    members.Remove(memberToDelete);
                    Members.Remove(memberToDelete);
                    await dataAccessor.SetMembers(members);
                }
            }
        }
    }
}
