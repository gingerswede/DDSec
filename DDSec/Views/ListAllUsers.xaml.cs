using BadDDSec.Models;
using BadDDSec.Storage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace BadDDSec.Views
{
    /// <summary>
    /// Interaction logic for ListAllUsers.xaml
    /// </summary>
    public partial class ListAllUsers : UserControl
    {
        public ObservableCollection<User> Users { get; set; }
        public ListAllUsers()
        {
            Users = new ObservableCollection<User>(UserStorage.Instance.GetAllUsers());
            InitializeComponent();
        }
        private void evntSaveUser(object sender, RoutedEventArgs e)
        {
            User user = ((Button)sender).DataContext as User;
            if (user.FirstName.Length > 2 &&
                user.FirstName.Length < 50 &&
                user.LastName.Length > 2 &&
                user.LastName.Length < 50 &&
                user.Email.Contains("@") &&
                !user.Email.EndsWith("@") &&
                !user.Email.StartsWith("@"))
                UserStorage.Instance.UpdateUser(user);
            else
                MessageBox.Show($"User {user.FullName} could not be saved. Errors while validating.",
                    "Error while saving.",
                    MessageBoxButton.OK,
                    MessageBoxImage.Stop);
        }

        private void evntDeleteUser(object sender, RoutedEventArgs e)
        {
            UserStorage.Instance.RemoveUser(((Button)sender).DataContext as User);
            Users.Remove(((Button)sender).DataContext as User);
        }
    }
}
