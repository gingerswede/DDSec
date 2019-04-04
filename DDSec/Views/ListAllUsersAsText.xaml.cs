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
    /// Interaction logic for ListAllUsersAsText.xaml
    /// </summary>
    public partial class ListAllUsersAsText : UserControl
    {
        public ObservableCollection<User> Users { get; set; }
        public ListAllUsersAsText()
        {
            Users = new ObservableCollection<User>(UserStorage.Instance.GetAllUsers());
            InitializeComponent();
        }
    }
}
