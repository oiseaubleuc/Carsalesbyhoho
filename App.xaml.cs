using Carsalesbyhoho.Data;
using Carsalesbyhoho.Models;
using System;
using System.Linq;
using System.Windows;

namespace Carsalesbyhoho
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            using var context = new AppDbContext();

            // Stap 1: Brands
            if (!context.Brands.Any())
            {
                context.Brands.AddRange(
                    new Brand { Id = 1, Naam = "Audi" },
                    new Brand { Id = 2, Naam = "BMW" },
                    new Brand { Id = 3, Naam = "Tesla" }
                );
            }

            // Stap 2: AutoTypes
            if (!context.AutoTypes.Any())
            {
                context.AutoTypes.AddRange(
                    new AutoType { Id = 1, Omschrijving = "SUV" },
                    new AutoType { Id = 2, Omschrijving = "Break" },
                    new AutoType { Id = 3, Omschrijving = "Sedan" }
                );
            }

            // FK-tabellen eerst opslaan
            context.SaveChanges();

            // Stap 3: Autos
            if (!context.Autos.Any())
            {
                var autos = new[]
                {
                    new Auto
                    {
                        Model = "Audi A4",
                        Prijs = 28000,
                        Bouwjaar = 2021,
                        Status = "Nieuw",
                        ImagePath = "audi4",
                        BrandId = 1,
                        AutoTypeId = 3
                    },
                    new Auto
                    {
                        Model = "BMW 320",
                        Prijs = 24000,
                        Bouwjaar = 2019,
                        Status = "Gebruikt",
                        ImagePath = "bmw4",
                        BrandId = 2,
                        AutoTypeId = 3
                    },
                    new Auto
                    {
                        Model = "Tesla Model 3",
                        Prijs = 45000,
                        Bouwjaar = 2022,
                        Status = "Nieuw",
                        ImagePath = "tesla",
                        BrandId = 3,
                        AutoTypeId = 1
                    }
                };

                context.Autos.AddRange(autos);
                context.SaveChanges();
            }
        }
    }
}
