using Carsalesbyhoho.Data;
using Carsalesbyhoho.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Carsalesbyhoho.Views
{
    public partial class Register : UserControl
    {
        public Register()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text.Trim();
            string email = EmailTextBox.Text.Trim();
            string password = PasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Alle velden zijn verplicht.", "Fout", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Wachtwoorden komen niet overeen.", "Fout", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using (var context = new AppDbContext())
            {
                if (context.Users.Any(u => u.Email == email))
                {
                    MessageBox.Show("E-mailadres is al geregistreerd.", "Fout", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var user = new Models.User
                {
                    Gebruikersnaam = name,
                    Email = email,
                    Wachtwoord = password
                };

                context.Users.Add(user);
                context.SaveChanges();
            }

            MessageBox.Show("Registratie succesvol!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

            ((MainWindow)Application.Current.MainWindow).MainContent.Content = new Login();
        }


        private void BackToLogin_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).MainContent.Content = new Login();
        }

    }
}

