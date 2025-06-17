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

using System.Linq;
using System.Windows.Controls;
using Carsalesbyhoho.Data;

namespace Carsalesbyhoho.Views
{
    public partial class UserList : UserControl
    {
        public UserList()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            using (var context = new AppDbContext())
            {
                var users = context.Users.ToList();
                UsersListControl.ItemsSource = users;
            }
        }


        private void UsersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
