using Carsalesbyhoho.Models;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Carsalesbyhoho.Views
{
    /// <summary>
    /// Interaction logic for AutoDetails.xaml
    /// </summary>
    public partial class AutoDetails : UserControl
    {
        public AutoDetails()
        {
            InitializeComponent();
        }

        public void SetAuto(Auto auto)
        {
            if (auto == null) return;

            // Tekstvakken instellen
            TitleText.Text = $"{auto.Brand?.Naam ?? "Onbekend merk"} {auto.Model ?? "Onbekend model"}";
            PriceText.Text = $"€ {auto.Prijs:N0}";
            DescriptionText.Text = $"Bouwjaar: {auto.Bouwjaar}";
            DescriptionText.Text += $"\nType: {auto.AutoType?.Omschrijving ?? "Onbekend"}";
            DescriptionText.Text += $"\nStatus: {auto.Status ?? "Niet gespecificeerd"}";

            // Afbeelding instellen
            try
            {
                var folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
                var imagePath = Path.Combine(folder, auto.ImagePath ?? "");

                string fullImage = File.Exists(imagePath) ? imagePath : auto.AfbeeldingUrl;

                var imageUri = fullImage.StartsWith("http", StringComparison.OrdinalIgnoreCase)
                    ? new Uri(fullImage)
                    : new Uri(fullImage, UriKind.Absolute);

                AutoImage.Source = new BitmapImage(imageUri);
            }
            catch (Exception ex)
            {
                AutoImage.Source = null;
                Console.WriteLine($"[Fout bij laden afbeelding]: {ex.Message}");
            }
        }
    }
}
