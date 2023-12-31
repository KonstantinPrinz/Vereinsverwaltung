using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace Vereinsverwaltung;
/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public partial class App : Application
{
    private Window m_window;

    public static ServiceProvider ServiceProvider;

    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        this.InitializeComponent();

        IServiceCollection services = new ServiceCollection();

        #region View
        services.AddSingleton<MainWindow>();
        services.AddTransient<MemberView>();
        services.AddTransient<DashboardView>();
        services.AddTransient<CreateMemberView>();
        services.AddTransient<ConfirmActionView>();
        services.AddTransient<AccountView>();
        services.AddTransient<ContributionView>();
        services.AddTransient<CreateContributionScaleView>();
        #endregion

        #region ViewModel
        services.AddTransient<MemberViewModel>();
        services.AddTransient<DashboardViewModel>();
        services.AddSingleton<MainWindowViewModel>();
        services.AddTransient<CreateMemberViewModel>();
        services.AddTransient<ConfirmActionViewModel>();
        services.AddTransient<AccountViewModel>();
        services.AddTransient<ContributionViewModel>();
        services.AddTransient<CreateContributionScaleViewModel>();
        #endregion ViewModel

        services.AddSingleton<DataAccessor>();
        services.AddSingleton<ViewModelToViewConverter>();
        services.AddSingleton<NavigationService>();
        services.AddSingleton<ResourceLoader>();
        services.AddSingleton<IDialogService, DialogService>();
        services.AddSingleton<Func<Type, ViewModelBase>>(serviceProvider => viewModelType => (ViewModelBase)serviceProvider.GetRequiredService(viewModelType));

        ServiceProvider = services.BuildServiceProvider();
    }

    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="args">Details about the launch request and process.</param>
    protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
    {
        m_window = ServiceProvider.GetRequiredService<MainWindow>();
        m_window.Activate();
    }
}
