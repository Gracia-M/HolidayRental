using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Models
{
    public class MembreCreate
    {
        [Required]
        [DisplayName("Nom")]
        [DataType(DataType.Text)]
        public string Nom { get; set; }

        [Required]
        [DisplayName("Prénom")]
        [DataType(DataType.Text)]
        public string Prenom { get; set; }

        [Required]
        [DisplayName("Email")]
        [DataType(DataType.Text)]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        [Required]
        public int idPays { get; set; }
        [DisplayName("Pays")]
        public IEnumerable<PaysDetails> ListePays { get; set; }

        [Required]
        [DisplayName("Téléphone")]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Le login est obligatoire.")]
        [DisplayName("Login")]
        [DataType(DataType.Text)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
        [DisplayName("Password")]
        [DataType(DataType.Password)]

        public string Password { get; set; }

        public ConnectionForm Connection { get; set; }

        public bool CheckCondition { get; set; }
    }
}
