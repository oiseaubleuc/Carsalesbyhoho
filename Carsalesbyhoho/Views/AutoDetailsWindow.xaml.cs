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

using Carsalesbyhoho.Models;
using System.Windows;

namespace Carsalesbyhoho.Views
{
    public partial class AutoDetailsWindow : Window
    {
        public AutoDetailsWindow(Auto geselecteerdeAuto)
        {
            InitializeComponent();
            DataContext = geselecteerdeAuto;
        }
        private void Sluiten_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
