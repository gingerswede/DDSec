
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace BetterDDSec
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private void evntUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show($"An unhandled exception occurred.\nMessage:\n{e.Exception.Message}", "An unhandled exception occurred.", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
        }
    }
}
