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
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace Vereinsverwaltung.View;

public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        this.InitializeComponent();
        RootGrid.DataContext = App.ServiceProvider.GetRequiredService<MainWindowViewModel>();
    }

    /// <summary>
    /// This code behind only exists to somehow set a <see cref="XamlRoot"/> to be used for a <see cref="ContentDialog"/>. <br/>
    /// Other ways as using <see href="https://github.com/microsoft/XamlBehaviors/wiki">Microsoft's XamlBehaviors</see> to set <br/>
    /// it in a ViewModel or an EventHandler for the window's <see cref="Window.Activated"/> event didn't seem to work. <br/>
    /// This resulted in either the <see cref="XamlRoot"/> being always <see langword="null"/> or not getting it set to non-null in time.
    /// </summary>
    private void RootGrid_Loaded(object sender, RoutedEventArgs e)
    {
        App.ServiceProvider.GetRequiredService<IDialogService>().XamlRoot = RootGrid.XamlRoot;
    }
}
