using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental.Models
{
    public class BienEchangeList
    {
        [ScaffoldColumn(false)]
        [Key]
        public int idBien { get; set; }

        [DisplayName("Titre")]
        public string titre { get; set; }

        [DisplayName("Resumé")]
        public string DescCourte { get; set; }

        [DisplayName("Capacité")]
        public int NombrePerson { get; set; }

        [DisplayName("Photo")]
        public string Photo { get; set; }
        public string Ville { get; set; }


        [ScaffoldColumn(false)]
        public int idPays { get; set; }
        public Pays Pays { get; set; }

        [DisplayName("Pays")]
        public string NomPays { get { return this.Pays.Libelle; } }


    }
}
