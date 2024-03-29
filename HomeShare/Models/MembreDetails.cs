﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Models
{
    public class MembreDetails
    {
        [ScaffoldColumn(false)]
        [Key]
        public int idMembre { get; set; }

        [DisplayName("Nom")]
        public string Nom { get; set; }

        [DisplayName("Prénom")]
        public string Prenom { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public int idPays { get; set; }
        public Pays Pays { get; set; }

        [DisplayName("Pays")]
        public string NomPays { get { return this.Pays.Libelle; } }

        [DisplayName("Téléphone")]
        public string Telephone { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Login")]
        public string Login { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}
