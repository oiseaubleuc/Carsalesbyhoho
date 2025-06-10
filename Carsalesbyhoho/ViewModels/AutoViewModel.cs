using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Carsalesbyhoho.Data;
using Carsalesbyhoho.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Carsalesbyhoho.ViewModels
{
    public partial class AutoViewModel : ObservableObject
    {
        private readonly AppDbContext _context;

        [ObservableProperty]
        private ObservableCollection<Auto> autos;

        [ObservableProperty]
        private Auto geselecteerdeAuto = new Auto();

        public AutoViewModel()
        {
            _context = new AppDbContext();
            Autos = new ObservableCollection<Auto>(_context.Autos.ToList());


        }

        [RelayCommand]
        private void VoegToe()
        {
            try
            {
                _context.Autos.Add(GeselecteerdeAuto);
                _context.SaveChanges();
                Autos.Add(GeselecteerdeAuto);
                GeselecteerdeAuto = new Auto();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fout bij toevoegen: {ex.Message}");
            }
        }

        [RelayCommand]
        private void Verwijder()
        {
            if (GeselecteerdeAuto != null)
            {
                try
                {
                    _context.Autos.Remove(GeselecteerdeAuto);
                    _context.SaveChanges();
                    Autos.Remove(GeselecteerdeAuto);
                    GeselecteerdeAuto = new Auto();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fout bij verwijderen: {ex.Message}");
                }
            }
        }

       
    }
}
