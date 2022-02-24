using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Models
{
    public class MembreList
    {
        [ScaffoldColumn(false)]
        [Key]
        public int idMembre { get; set; }

        [DisplayName("Nom")]
        public string Nom { get; set; }

        [DisplayName("Prénom")]
        public string Prenom { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public int Pays { get; set; }
        public PaysDetails ListePays { get; set; }

        [DisplayName("Pays")]
        public string NomPays { get { return this.ListePays.Libelle; } }

        [DisplayName("Téléphone")]
        public string Telephone { get; set; }
    }
}
