using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Vpn;

namespace Vereinsverwaltung.ViewModel;
public partial class CreateContributionScaleViewModel : ViewModelBase
{
    [ObservableProperty]
    private EmploymentType employment;
    [ObservableProperty]
    private double contribution;
    [ObservableProperty]
    private int minAge;
    [ObservableProperty]
    private int maxAge;

    [ObservableProperty]
    private IEnumerable<EmploymentType> employmentTypes;

    public CreateContributionScaleViewModel(DataAccessor dataAccessor, ResourceLoader resourceLoader) : base(dataAccessor, resourceLoader)
    {
        EmploymentTypes = Enum.GetValues(typeof(EmploymentType)).Cast<EmploymentType>();
    }
}
