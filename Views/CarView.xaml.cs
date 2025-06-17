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
using Carsalesbyhoho.Data; 
using Microsoft.EntityFrameworkCore; 
using Carsalesbyhoho.Data;
using Carsalesbyhoho.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Carsalesbyhoho.Views
{
    public partial class CarView : UserControl
    {
        private readonly AppDbContext _context = new AppDbContext();

        public CarView()
        {
            InitializeComponent();
            LoadCars();
        }

        private void LoadCars()
        {
            var autos = _context.Autos
                .Include(a => a.Brand)
                .Include(a => a.AutoType)
                .ToList();

            CarsList.ItemsSource = autos;
        }

        private void DetailsButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.DataContext is Auto auto)
            {
                var detailsView = new AutoDetails();
                detailsView.SetAuto(auto);

                ((MainWindow)Application.Current.MainWindow).MainContent.Content = detailsView;
            }
        }

    }
}
