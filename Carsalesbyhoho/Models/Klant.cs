using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Carsalesbyhoho.Models
{
    public class Klant
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Contactgegevens { get; set; }

        public ICollection<Verkoop> Verkopen { get; set; }
    }
}
