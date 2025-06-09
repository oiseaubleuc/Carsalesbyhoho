using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Carsalesbyhoho.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Gebruikersnaam { get; set; }

        [Required]
        public string Wachtwoord { get; set; }

        public string Rol { get; set; } = "Bezoeker";
    }
}
