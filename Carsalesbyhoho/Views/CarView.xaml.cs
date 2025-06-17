using Carsalesbyhoho.Models;
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
using Carsalesbyhoho.ViewModels;
using Carsalesbyhoho.Views;





namespace Carsalesbyhoho.Views
{
    /// <summary>
    /// Interaction logic for CarView.xaml
    /// </summary>
    public partial class CarView : UserControl
    {
        public CarView()
        {
            InitializeComponent();
        }

        private void DetailsButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.DataContext is Auto auto)
            {
                var vm = new AutoDetailsViewModel { Auto = auto };
                var view = new AutoDetails { DataContext = vm };
                var detailsWindow = new AutoDetails
                {
                    DataContext = auto
                };
                detailsWindow.ShowDialog();

            }
        }

    }
}
