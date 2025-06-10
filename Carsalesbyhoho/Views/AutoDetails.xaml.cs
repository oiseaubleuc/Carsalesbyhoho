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
using System.Windows.Shapes;

namespace Carsalesbyhoho.Views
{
    /// <summary>
    /// Interaction logic for AutoDetails.xaml
    /// </summary>
    public partial class AutoDetails : Window
    {
        public AutoDetails()
        {
            InitializeComponent();
        }
        private void DetailsButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.DataContext is Auto selectedAuto)
            {
                var window = new AutoDetails
                {
                    DataContext = selectedAuto
                };
                window.ShowDialog();
            }
        }

    }
}
