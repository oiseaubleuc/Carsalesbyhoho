using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carsalesbyhoho.Models;
using System.Collections.Generic;

namespace Carsalesbyhoho.Data
{
    public static class DataSeeder
    {
        public static List<Auto> SeedAutos()
        {
            return new List<Auto>
            {
                new Auto
                {
                    Model = "Audi A4",
                    Prijs = 28000,
                    Bouwjaar = 2021,
                    Status = "Nieuw",
                    ImagePath = "audi4.jpg",
                    BrandId = 2,        
                    AutoTypeId = 3      
                },
                new Auto
                {
                    Model = "BMW 320",
                    Prijs = 24000,
                    Bouwjaar = 2019,
                    Status = "Gebruikt",
                    ImagePath = "bmw4.png",
                    BrandId = 2,
                    AutoTypeId = 4
                },
                new Auto
                {
                    Model = "Tesla Model 3",
                    Prijs = 45000,
                    Bouwjaar = 2022,
                    Status = "Nieuw",
                    ImagePath = "tesla.png",
                    BrandId = 3,        
                    AutoTypeId = 1
                }
            };

        }
    }
}
