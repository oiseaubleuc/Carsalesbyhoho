using Carsalesbyhoho.Models;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Carsalesbyhoho.Models;
using System;
using System.IO;
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
            ModelTextBlock.Text = auto.Model;
            PrijsTextBlock.Text = $"\u20AC {auto.Prijs:N2}";
            BouwjaarTextBlock.Text = auto.Bouwjaar.ToString();
            StatusTextBlock.Text = auto.Status;
            OmschrijvingTextBlock.Text = auto.Omschrijving;

            if (!string.IsNullOrEmpty(auto.ImagePath))
            {
                string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", auto.ImagePath);
                if (File.Exists(fullPath))
                {
                    CarImage.Source = new BitmapImage(new Uri(fullPath));
                }
            }
        }
    }
}
