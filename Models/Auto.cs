using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carsalesbyhoho.Models
{
    public class Auto
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Bouwjaar { get; set; }
        public decimal Prijs { get; set; }
        public string Omschrijving { get; set; } = "Geen omschrijving beschikbaar.";


        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public string Status { get; set; }
        public int AutoTypeId { get; set; }
        public AutoType AutoType { get; set; }
        public string ImagePath { get; set; }


        public ICollection<Verkoop> Verkopen { get; set; }
        public string AfbeeldingUrl { get; set; } = "https://via.placeholder.com/280x140.png?text=Auto";

    }
}
