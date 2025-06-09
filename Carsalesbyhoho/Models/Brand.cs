using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carsalesbyhoho.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Naam { get; set; }

        public ICollection<Auto> Autos { get; set; }
    }
}
