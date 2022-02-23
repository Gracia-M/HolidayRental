using System;
using System.Collections.Generic;
using System.Text;

namespace HoliDayRental.BLL.Entities
{
    public class OptionsBien
    {
        public int idOption { get; set; }
        public int idBien { get; set; }
        public string Valeur { get; set; }
        public BienEchange Bien { get; set; }
        public Options Option { get; set; }

        public OptionsBien(string valeur, BienEchange bien, Options option)
        {
            Valeur = valeur;
            Bien = bien;
            if (bien == null) throw new ArgumentNullException(nameof(idBien));
            idBien = bien.idBien;
            Option = option;
            if (option == null) throw new ArgumentNullException(nameof(idOption));
            idOption = option.idOption;
        }

        public OptionsBien(string valeur, int option_id, int bien_id)
        {
            Valeur = valeur;
            idOption = option_id;
            idBien = bien_id;
            BienEchange = null;
            Options = null;
        }

    }
}
