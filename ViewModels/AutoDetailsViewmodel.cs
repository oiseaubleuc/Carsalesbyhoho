using Carsalesbyhoho.Models;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using Carsalesbyhoho.Models;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;

namespace Carsalesbyhoho.ViewModels
{
    public class AutoDetailsViewModel : INotifyPropertyChanged
    {
        public Auto Auto { get; set; }

        private bool _isFavorite;
        public bool IsFavorite
        {
            get => _isFavorite;
            set { _isFavorite = value; OnPropertyChanged(nameof(IsFavorite)); OnPropertyChanged(nameof(HeartIcon)); OnPropertyChanged(nameof(HeartColor)); }
        }

        public string HeartIcon => IsFavorite ? "❤️" : "🤍";
        public Brush HeartColor => IsFavorite ? Brushes.Red : Brushes.White;

        public ICommand ToggleFavoriteCommand { get; }

        public AutoDetailsViewModel()
        {
            ToggleFavoriteCommand = new RelayCommand(ToggleFavorite);
        }

        private void ToggleFavorite()
        {
            IsFavorite = !IsFavorite;
            // TODO: Voeg auto toe/verwijder uit favorietenlijst (bijv. via service of DB)
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string prop) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
