using System.Windows;
using System.Windows.Controls;
using Carsalesbyhoho.Views;

namespace Carsalesbyhoho.Views
{
    public partial class AdminDashboard : UserControl
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void AddCar_Click(object sender, RoutedEventArgs e)
        {
            DashboardContent.Content = new AddCar(); 
        }

        private void ShowUsers_Click(object sender, RoutedEventArgs e)
        {
            DashboardContent.Content = new UserList();
        }

    }
}
