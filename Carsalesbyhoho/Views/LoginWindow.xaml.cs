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
using System.Windows.Shapes;
using System.Windows;

namespace Carsalesbyhoho.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var username = UsernameBox.Text.Trim();
            var password = PasswordBox.Password;

            // Simpele check
            if (username == "admin" && password == "admin123")
            {
                MainWindow main = new MainWindow(true); 
                main.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ongeldige inloggegevens", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
