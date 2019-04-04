using BetterDDSec.Models;
using BetterDDSec.Storage;
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

namespace BetterDDSec.Views
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

            var validationResult = User.IsValid;

            if (validationResult.validationResult)
                try {
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
                catch
                {
                    MessageBox.Show("Could not validate the new user.",
                        "Error while validating.",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            else
            {
                List<string> validationMessages = new List<string>();
                foreach (var vr in validationResult.validationMessages)
                {
                    validationMessages.Add(vr.ErrorMessage);
                }
                MessageBox.Show($"The following errors have to be corrected:\n{string.Join("\n", validationMessages)}", "Error while saving", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void evntClear(object sender, RoutedEventArgs e)
        {
            User = new User();
            DataContext = User;
        }
    }
}
