using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Models
{
    public class MembreEdit
    {
            [Required]
            [DisplayName("Nom")]
            public string Nom { get; set; }

            [Required]
            [DisplayName("Prénom")]
            public string Prenom { get; set; }

            [Required]
            [DisplayName("Email")]
            public string Email { get; set; }

            [ScaffoldColumn(false)]
            [Required]
            public int idPays { get; set; }
            [DisplayName("Pays")]
            public IEnumerable<Pays> ListePays { get; set; }

            [Required]
            [DisplayName("Téléphone")]
            public string Telephone { get; set; }

            [Required]
            [DisplayName("Login")]
            public string Login { get; set; }

            [DisplayName("Nouveau Password")]
            public string Password { get; set; }
        }
}
