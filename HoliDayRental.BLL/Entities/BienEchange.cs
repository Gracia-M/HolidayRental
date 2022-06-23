
using System;
using System.Collections.Generic;
using System.Text;

namespace HoliDayRental.BLL.Entities
{
    public class BienEchange
    {
        public int idBien { get; set; }
        public string titre { get; set; }
        public string DescCourte { get; set; }
        public string DescLong { get; set; }
        public int NombrePerson { get; set; } 
        public Pays Pays { get; set; }
        public int Pays_Id { get; set; }
        public string Ville { get; set; }
        public string Rue { get; set; }
        public string Numero { get; set; }
        public string CodePostal { get; set; }
        public string Photo { get; set; }
        public bool AssuranceObligatoire { get; set; }
        public bool isEnabled { get; set; }
        public DateTime? DisabledDate { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public Membre Membre { get; set; }
        public int Membre_Id { get; set; }
        public DateTime DateCreation { get; set; }


        //public IEnumerable<OptionsBien> ListeOptions { get; set; }


        public BienEchange(int id, string title, string shortDescr, string longDescr, int nrOfPeople, Pays pays, string city, string street, string number, string zipcode, string picture, bool insurance, string latitude, string longitude, Membre member)
        {
            idBien = id;
            titre = title;
            DescCourte = shortDescr;
            DescLong = longDescr;
            NombrePerson = nrOfPeople;
            Pays = pays;
            if (pays == null) throw new ArgumentNullException(nameof(Pays_Id));
            Pays_Id = pays.idPays;
            Ville = city;
            Rue = street;
            Numero = number;
            CodePostal = zipcode;
            Photo = picture;
            AssuranceObligatoire = insurance;
            Latitude = latitude;
            Longitude = longitude;
            Membre = member;
            if (member == null) throw new ArgumentNullException(nameof(Membre_Id));
            Membre_Id = member.idMembre;


        }

        public BienEchange(int id, string title, string shortDescr, string longDescr, int nrOfPeople, int pays_id, string city, string street, string number, string zipcode, string picture, bool insurance, string latitude, string longitude, int member_id)
        {
            idBien = id;
            titre = title;
            DescCourte = shortDescr;
            DescLong = longDescr;
            NombrePerson = nrOfPeople;
            Pays_Id = pays_id;
            Ville = city;
            Rue = street;
            Numero = number;
            CodePostal = zipcode;
            Photo = picture;
            AssuranceObligatoire = insurance;
            Latitude = latitude;
            Longitude = longitude;
            Membre_Id = member_id;
        }
    }

}
