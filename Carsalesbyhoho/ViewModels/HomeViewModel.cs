using Carsalesbyhoho.Models;
using Carsalesbyhoho.Data;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using CommunityToolkit.Mvvm.Input;

namespace Carsalesbyhoho.ViewModels
{
    public class HomeViewModel
    {
        public ObservableCollection<Auto> FeaturedCars { get; set; }
        public ICommand ViewDetailsCommand { get; set; }

        public HomeViewModel()
        {
            using (var db = new AppDbContext())
            {
                var cars = db.Autos
              .ToList()
              .OrderByDescending(a => a.Prijs)
              .Take(6)
              .ToList();

                FeaturedCars = new ObservableCollection<Auto>(cars);
            }

            ViewDetailsCommand = new RelayCommand<Auto>(ViewCarDetails);
        }

        private void ViewCarDetails(Auto auto)
        {
            System.Windows.MessageBox.Show($"Details van {auto.Model} - {auto.Prijs:C}");
        }
    }
}
