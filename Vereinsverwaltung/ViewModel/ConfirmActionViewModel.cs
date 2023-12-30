using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vereinsverwaltung.ViewModel;

public class ConfirmActionViewModel : ViewModelBase
{
    public ConfirmActionViewModel(DataAccessor dataAccessor, ResourceLoader resourceLoader) : base(dataAccessor, resourceLoader)
    {
    }
}
