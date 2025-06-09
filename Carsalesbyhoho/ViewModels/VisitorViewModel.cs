using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Carsalesbyhoho.Data;
using Carsalesbyhoho.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace Carsalesbyhoho.ViewModels
{
    public partial class VisitorViewModel : ObservableObject
    {
        private readonly AppDbContext _context;

        [ObservableProperty]
        private ObservableCollection<Auto> autos;

        [ObservableProperty]
        private string zoekterm;

        [ObservableProperty]
        private ObservableCollection<Brand> merken;

        [ObservableProperty]
        private Brand geselecteerdMerk;

        public VisitorViewModel()
        {
            _context = new AppDbContext();
            LaadMerken();
            FilterAutos();
        }

        partial void OnZoektermChanged(string value) => FilterAutos();
        partial void OnGeselecteerdMerkChanged(Brand value) => FilterAutos();

        private void LaadMerken()
        {
            Merken = new ObservableCollection<Brand>(_context.Brands.ToList());
        }

        private void FilterAutos()
        {
            var query = _context.Autos.Include(a => a.Brand).AsQueryable();

            if (!string.IsNullOrWhiteSpace(Zoekterm))
                query = query.Where(a => a.Model.Contains(Zoekterm));

            if (GeselecteerdMerk != null)
                query = query.Where(a => a.MerkId == GeselecteerdMerk.Id);

            Autos = new ObservableCollection<Auto>(query.ToList());
        }
    }
}
