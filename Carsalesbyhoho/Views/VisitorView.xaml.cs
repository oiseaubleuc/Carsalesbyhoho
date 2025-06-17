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

using System.Windows.Controls;
using Carsalesbyhoho.Models;

namespace Carsalesbyhoho.Views
{
    public partial class VisitorView : UserControl
    {
        public VisitorView()
        {
            InitializeComponent();
        }

        private void BekijkDetails_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as FrameworkElement;
            if (button?.Tag is Auto geselecteerdeAuto)
            {
                var detailsWindow = new AutoDetailsWindow(geselecteerdeAuto);
                detailsWindow.Owner = Window.GetWindow(this);
                detailsWindow.ShowDialog();
            }
        }
    }
}
