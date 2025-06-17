using Carsalesbyhoho.Data;
using Carsalesbyhoho.Models;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Carsalesbyhoho.ViewModels
{
    public class AddCarViewModel : INotifyPropertyChanged
    {
        public string Model { get; set; }
        public string Prijs { get; set; }
        public string Bouwjaar { get; set; }
        public string SelectedImagePath { get; set; }

        private BitmapImage _previewImage;
        public BitmapImage PreviewImage
        {
            get => _previewImage;
            set { _previewImage = value; OnPropertyChanged(nameof(PreviewImage)); }
        }

        public ICommand SelectImageCommand { get; }
        public ICommand SaveCommand { get; }

        public AddCarViewModel()
        {
            SelectImageCommand = new RelayCommand(SelectImage);
            SaveCommand = new RelayCommand(SaveCar);
        }

        private void SelectImage()
        {
            var dialog = new OpenFileDialog
            {
                Title = "Kies afbeelding",
                Filter = "Afbeeldingen (*.png;*.jpg)|*.png;*.jpg"
            };

            if (dialog.ShowDialog() == true)
            {
                var imageDir = Path.Combine(Directory.GetCurrentDirectory(), "Images");
                Directory.CreateDirectory(imageDir);
                var filename = Path.GetFileName(dialog.FileName);
                var destPath = Path.Combine(imageDir, filename);
                File.Copy(dialog.FileName, destPath, true);
                SelectedImagePath = $"Images/{filename}";
                PreviewImage = new BitmapImage(new Uri(destPath));
            }
        }

        private void SaveCar()
        {
            if (!decimal.TryParse(Prijs, out var prijs) || !int.TryParse(Bouwjaar, out var jaar))
            {
                MessageBox.Show("Voer geldige waarden in.");
                return;
            }

            var newCar = new Auto
            {
                Model = Model,
                Prijs = prijs,
                Bouwjaar = jaar,
                ImagePath = SelectedImagePath,
                Status = "Nieuw"
            };

            using var db = new AppDbContext();
            db.Autos.Add(newCar);
            db.SaveChanges();

            MessageBox.Show("Auto succesvol toegevoegd!", "✅");
            CloseWindow();
        }

        private void CloseWindow()
        {
            foreach (Window win in Application.Current.Windows)
            {
                if (win is Window && win.Title == "Nieuwe Auto Toevoegen")
                {
                    win.Close();
                    break;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
