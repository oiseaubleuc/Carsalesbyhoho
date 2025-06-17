using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Carsalesbyhoho.Models
{
    public class Verkoop
    {
        public int Id { get; set; }

        public int AutoId { get; set; }
        public Auto Auto { get; set; }

        public int KlantId { get; set; }
        public Klant Klant { get; set; }

        public DateTime Datum { get; set; }
        public bool Betaald { get; set; }
    }
}
