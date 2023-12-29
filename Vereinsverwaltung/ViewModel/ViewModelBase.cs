using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vereinsverwaltung.ViewModel;

public abstract partial class ViewModelBase : ObservableObject
{
    protected readonly DataAccessor dataAccessor;
    protected readonly ResourceLoader resourceLoader;

    [ObservableProperty]
    private string navigationDisplayHeader;

    public ViewModelBase(DataAccessor dataAccessor, ResourceLoader resourceLoader)
    {
        this.dataAccessor = dataAccessor;
        this.resourceLoader = resourceLoader;
        NavigationDisplayHeader = resourceLoader.GetString(GetType().Name);
    }
}
