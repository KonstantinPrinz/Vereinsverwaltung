﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vereinsverwaltung.ViewModel;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private NavigationService navigationService;

    public MainWindowViewModel(DataAccessor dataAccessor, ResourceLoader resourceLoader, 
        NavigationService navigationService) : base(dataAccessor, resourceLoader)
    {
        NavigationService = navigationService;
    }

    [RelayCommand]
    private void NavigateToDashboardView()
    {
        NavigationService.NavigateTo<DashboardViewModel>();
    }

    [RelayCommand]
    private void NavigateToMemberView()
    {
        NavigationService.NavigateTo<MemberViewModel>();
    }
}
