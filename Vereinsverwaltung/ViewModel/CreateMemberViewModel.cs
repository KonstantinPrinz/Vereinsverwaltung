using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vereinsverwaltung.ViewModel;
public partial class CreateMemberViewModel : ViewModelBase
{
    [ObservableProperty]
    private string firstName;
    [ObservableProperty]
    private string lastName;
    [ObservableProperty]
    private DateTime birthDate = DateTime.Now;
    [ObservableProperty]
    private EmploymentType employment;
    [ObservableProperty]
    private string iban;

    [ObservableProperty]
    private IEnumerable<EmploymentType> employmentTypes;

    public CreateMemberViewModel(DataAccessor dataAccessor, ResourceLoader resourceLoader) : base(dataAccessor, resourceLoader)
    {
        EmploymentTypes = Enum.GetValues(typeof(EmploymentType)).Cast<EmploymentType>();
    }
}
