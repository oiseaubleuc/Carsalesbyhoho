using Carsalesbyhoho.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Carsalesbyhoho.ViewModels;

using Carsalesbyhoho.Views;
using System.Windows;

namespace Carsalesbyhoho
{
    public partial class MainWindow : Window
    {
        private bool IsAdmin;

        public MainWindow()
        {
            InitializeComponent();
            MainContent.Content = new HomeView(); // standaard
        }

        public MainWindow(bool isAdmin) : this() // chained constructor
        {
            IsAdmin = isAdmin;
            DataContext = new MainViewModel(IsAdmin);
        }


        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new HomeView();
        }

        private void CarsButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new CarView();
            CarView view = new CarView();
            view.DataContext = new AutoViewModel();

        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var login = new LoginWindow();
            login.ShowDialog();
        }

        //private void FavoritesMenu_Click(object sender, RoutedEventArgs e)
        //{
        //    // check login hier later
        //    MainContent.Content = new FavoritesView();
        //}

    }
}
