using System;
using System.Collections.Generic;
using System.Text;

namespace HoliDayRental.BLL.Entities
{
    public class Options
    {
        public int idOption { get; set; }

        private string _libelle;
        public string Libelle
        {
            get { return _libelle; }
            set {
                string newLibelle = value.Trim();
                if (string.IsNullOrEmpty(newLibelle)) throw new ArgumentNullException(nameof(newLibelle));
                _libelle = newLibelle;
            }
        }
        public Options(int id, string libelle)
        {
            idOption = id;
            Libelle = libelle;
        }

    }
}
