using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vereinsverwaltung.ViewModel;

public class DashboardViewModel : ViewModelBase
{
    public DashboardViewModel(DataAccessor dataAccessor, 
        ResourceLoader resourceLoader) : base(dataAccessor, resourceLoader)
    {
    }
}
