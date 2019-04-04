using BadDDSec.Models;
using BadDDSec.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace BadDDSec.Views
{
    /// <summary>
    /// Interaction logic for RegisterUser.xaml
    /// </summary>
    public partial class RegisterUser : UserControl
    {
        User User { get; set; }
        string Heading { get; set; }
        private bool NewUser { get; set; }

        public RegisterUser()
        {
            InitializeComponent();
            User = new User();
            DataContext = User;
            NewUser = true;
        }

        public RegisterUser(User user) : this()
        {
            User = user;
            NewUser = false;
        }

        private void evntSave(object sender, RoutedEventArgs e)
        {
            string nameRegex = @"(\D\S)\w{1,50}";
            string emailRegex = @"^(?=.*\S)[-!#$%&\'*+\/=?^_`{|}~,.a-z0-9]{1,64}[@]{1}[-.a-zåäö0-9]{4,253}$";

            if (!string.IsNullOrEmpty(User.Email) &&
                Regex.IsMatch(User.Email, emailRegex) &&
                !string.IsNullOrEmpty(User.FirstName) &&
                Regex.IsMatch(User.FirstName, nameRegex) &&
                !string.IsNullOrEmpty(User.LastName) &&
                Regex.IsMatch(User.LastName, nameRegex))
            {

                if (NewUser)
                {
                    UserStorage.Instance.AddUser(User);
                }
                else
                {
                    UserStorage.Instance.UpdateUser(User);
                }

                evntClear(sender, e);
            }
            else
            {
                MessageBox.Show("Could not validate the new user.",
                    "Error while validating.",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void evntClear(object sender, RoutedEventArgs e)
        {
            User = new User();
            DataContext = User;
        }
    }
}
