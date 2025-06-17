using Carsalesbyhoho.Models;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Carsalesbyhoho.Views
{
    public partial class AutoDetails : UserControl
    {
        public AutoDetails()
        {
            InitializeComponent();
        }

        public void SetAuto(Auto auto)
        {
            if (auto == null)
            {
                // Verberg indien geen auto beschikbaar is
                this.Visibility = Visibility.Collapsed;
                return;
            }

            // ✏️ Basisgegevens tonen
            TitleText.Text = $"{auto.Brand?.Naam ?? "Onbekend merk"} {auto.Model ?? "Onbekend model"}";
            PriceText.Text = $"€ {auto.Prijs:N0}";

            // 📄 Beschrijving opbouwen
            DescriptionText.Text = string.Empty;
            DescriptionText.Text += $"Bouwjaar: {auto.Bouwjaar}\n";
            DescriptionText.Text += $"Type: {auto.AutoType?.Omschrijving ?? "Onbekend"}\n";
            DescriptionText.Text += $"Status: {auto.Status ?? "Niet gespecificeerd"}\n";
            DescriptionText.Text += $"Omschrijving: {(!string.IsNullOrWhiteSpace(auto.Omschrijving) ? auto.Omschrijving : "Geen omschrijving beschikbaar.")}";

            // 🖼️ Afbeelding laden (lokaal of URL)
            try
            {
                string imagesDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
                string localPath = Path.Combine(imagesDir, auto.ImagePath ?? "");
                string selectedPath = File.Exists(localPath) ? localPath : auto.AfbeeldingUrl;

                AutoImage.Source = new BitmapImage(new Uri(selectedPath, UriKind.Absolute));
            }
            catch (Exception ex)
            {
                AutoImage.Source = null;
                Console.WriteLine($"[Fout bij laden afbeelding]: {ex.Message}");
            }

            // ✨ Details tonen
            this.Visibility = Visibility.Visible;
        }
    }
}
