using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Carsalesbyhoho.Data;
using Carsalesbyhoho.Models;

using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Carsalesbyhoho.Data;
using Carsalesbyhoho.Models;

namespace Carsalesbyhoho.Views
{
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();

            if (Session.CurrentUser != null)
                ShowProfile();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string email = UsernameBox.Text.Trim();
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Gelieve e-mail en wachtwoord in te vullen.", "Fout", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using (var context = new AppDbContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Email == email && u.Wachtwoord == password);

                if (user != null)
                {
                    Session.CurrentUser = user; 
                    ShowProfile();

                    MessageBox.Show("Succesvol ingelogd!", "Welkom", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Ongeldige inloggegevens.", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ShowProfile()
        {
            var user = Session.CurrentUser;

            NaamText.Text = $"👤 Gebruikersnaam: {user.Gebruikersnaam}";
            EmailText.Text = $"📧 Email: {user.Email}";
            RolText.Text = $"🛡️ Rol: {user.Rol}";

            LoginPanel.Visibility = Visibility.Collapsed;
            ProfilePanel.Visibility = Visibility.Visible;
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Session.CurrentUser = null;

            LoginPanel.Visibility = Visibility.Visible;
            ProfilePanel.Visibility = Visibility.Collapsed;

            UsernameBox.Clear();
            PasswordBox.Clear();
        }

        private void RegisterLink_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).MainContent.Content = new Register();
        }
    }
}

