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
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Alle velden zijn verplicht.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Wachtwoorden komen niet overeen.");
                return;
            }

            MessageBox.Show("Registratie succesvol!");

            this.Close();
        }
        private void BackToLogin_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // sluit het registratievenster
        }

    }
}
