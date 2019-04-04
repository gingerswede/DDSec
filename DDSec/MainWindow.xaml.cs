using BadDDSec.Storage;
using BadDDSec.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BadDDSec
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            UserStorage.Instance.GenerateContent(10);
            InitializeComponent();
        }

        private void evntGoToRegisterNew(object sender, RoutedEventArgs e)
        {
            grdContent.Children.Clear();
            grdContent.Children.Add(new RegisterUser());
        }

        private void evntGoToListAll(object sender, RoutedEventArgs e)
        {
            grdContent.Children.Clear();
            grdContent.Children.Add(new ListAllUsers());
        }

        private void evntCloseApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void evntGoToListAllAsText(object sender, RoutedEventArgs e)
        {
            grdContent.Children.Clear();
            grdContent.Children.Add(new ListAllUsersAsText());
        }
    }
}
