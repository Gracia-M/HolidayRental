using System;
using System.Collections.Generic;
using System.Text;

namespace HoliDayRental.BLL.Entities
{
    public class Pays
    {
        public int idPays { get; set; }
        public string Libelle { get; set; }

        public Pays(int id, string libelle)
        {
            idPays = id;
            Libelle = libelle;
        }
    }
}
