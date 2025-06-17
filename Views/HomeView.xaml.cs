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

using Carsalesbyhoho.Data;
using Carsalesbyhoho.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Carsalesbyhoho.Views
{
    public partial class HomeView : UserControl
    {
        private readonly AppDbContext _context;

        public HomeView()
        {
            InitializeComponent();
            _context = new AppDbContext();

            LoadFilters();
            LoadCars();
        }

        private void LoadFilters()
        {
            // Dropdowns vullen met unieke waarden
            BrandFilterBox.ItemsSource = _context.Brands.ToList();
            BrandFilterBox.DisplayMemberPath = "Naam";

            TypeFilterBox.ItemsSource = _context.AutoTypes.ToList();
            TypeFilterBox.DisplayMemberPath = "Omschrijving";
        }

        private void LoadCars()
        {
            var autos = _context.Autos
                .Include(a => a.Brand)
                .Include(a => a.AutoType)
                .ToList();

            FilteredCarList.ItemsSource = autos;
        }

        private void FilterChanged(object sender, RoutedEventArgs e)
        {
            string zoekterm = SearchBox.Text.ToLower();
            string gekozenMerk = (BrandFilterBox.SelectedItem as Brand)?.Naam;
            string gekozenType = (TypeFilterBox.SelectedItem as AutoType)?.Omschrijving;

            var gefilterd = _context.Autos
                .Include(a => a.Brand)
                .Include(a => a.AutoType)
                .Where(a =>
                    (string.IsNullOrEmpty(zoekterm) || a.Model.ToLower().Contains(zoekterm)) &&
                    (gekozenMerk == null || a.Brand.Naam == gekozenMerk) &&
                    (gekozenType == null || a.AutoType.Omschrijving == gekozenType)
                ).ToList();

            FilteredCarList.ItemsSource = gefilterd;
        }
    }
}
