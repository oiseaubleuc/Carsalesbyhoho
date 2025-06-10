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

        [Required(ErrorMessage = "Gebruikersnaam is verplicht")]
        [StringLength(50, MinimumLength = 3)]
        public string Gebruikersnaam { get; set; }

        [Required(ErrorMessage = "Wachtwoord is verplicht")]
        [StringLength(100, MinimumLength = 6)]
        public string Wachtwoord { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Rol { get; set; } = "Bezoeker";

        public DateTime GeregistreerdOp { get; set; } = DateTime.Now;
    }

}
