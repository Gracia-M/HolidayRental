using System;
using System.Collections.Generic;
using System.Text;

namespace HoliDayRental.DAL.Entities
{
    public class AvisMembreBien
    {
        public int idAvis { get; set; }
        public int note { get; set; }
        public string message { get; set; }
        public int idMembre { get; set; }
        public int idBien { get; set; }
        public DateTime DateAvis { get; set; }
        public bool Approuve { get; set; }

    }
}
