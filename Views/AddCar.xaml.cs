using Carsalesbyhoho.Data;
using Carsalesbyhoho.Models;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Carsalesbyhoho.Views
{
    public partial class AddCar : UserControl
    {
        private readonly AppDbContext _context = new AppDbContext();
        private string selectedImageFileName = "";

        public AddCar()
        {
            InitializeComponent();

            BrandstofBox.ItemsSource = _context.Brands.ToList(); // als placeholder
            TypeBox.ItemsSource = _context.AutoTypes.ToList();
        }

        private void SelectImage_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Afbeeldingen (*.png;*.jpg)|*.png;*.jpg"
            };

            if (dialog.ShowDialog() == true)
            {
                string imagesDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
                if (!Directory.Exists(imagesDir))
                    Directory.CreateDirectory(imagesDir);

                string fileName = Path.GetFileName(dialog.FileName);
                string destinationPath = Path.Combine(imagesDir, fileName);

                File.Copy(dialog.FileName, destinationPath, overwrite: true);

                selectedImageFileName = fileName;
                SelectedImagePath.Text = $"Geselecteerd: {fileName}";
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedBrand = BrandstofBox.SelectedItem as Brand;
            var selectedType = TypeBox.SelectedItem as AutoType;

            if (selectedBrand == null || selectedType == null)
            {
                MessageBox.Show("Selecteer een merk en autotype.");
                return;
            }

            var auto = new Auto
            {
                Model = ModelBox.Text,
                Bouwjaar = int.TryParse(BouwjaarBox.Text, out var jaar) ? jaar : 0,
                Prijs = decimal.TryParse(PrijsBox.Text, out var prijs) ? prijs : 0,
                Status = (StatusBox.SelectedItem as ComboBoxItem)?.Content.ToString(),
                BrandId = selectedBrand.Id,
                AutoTypeId = selectedType.Id,
                ImagePath = selectedImageFileName,
                Omschrijving = OmschrijvingBox.Text
            };

            _context.Autos.Add(auto);
            _context.SaveChanges();

            MessageBox.Show("Auto succesvol toegevoegd!");
        }
    }
}
