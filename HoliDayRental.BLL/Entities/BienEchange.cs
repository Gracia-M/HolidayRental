using HoliDayRental.DAL.Entities;
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
        public DateTime DateCreation { get; set; }
        public int Pays { get; set; }
        public int idMembre { get; set; }
        public Pays Pays { get; set; }
        public Membre Membre { get; set; }

        public IEnumerable<OptionsBien> Options { get; set; }


        public BienEchange(int id, string title, string shortDescr, string longDescr, int nrOfPeople, string city, string street, string number, string zipcode, string picture, bool insurance, bool enable, DateTime disable, string latitude, string longitude, DateTime creation, Pays country, Membre member)
        {
            idBien = id;
            titre = title;
            DescCourte = shortDescr;
            DescLong = longDescr;
            NombrePerson = nrOfPeople;
            Ville = city;
            Rue = street;
            Numero = number;
            CodePostal = zipcode;
            Photo = picture;
            AssuranceObligatoire = insurance;
            isEnabled = enable;
            DisabledDate = disable;
            Latitude = latitude;
            Longitude = longitude;
            DateCreation = creation;
            if (country == null) throw new ArgumentNullException(nameof(Pays));
            Pays = country;
            Membre = member;
            if (member == null) throw new ArgumentNullException(nameof(idMembre));
            idMembre = member.idMembre;
        }

        public BienEchange(int id, string title, string shortDescr, string longDescr, int nrOfPeople, string city, string street, string number, string zipcode, string picture, bool insurance, bool enable, DateTime disable, string latitude, string longitude, DateTime creation, int pays_id, int member_id)
        {
            idBien = id;
            titre = title;
            DescCourte = shortDescr;
            DescLong = longDescr;
            NombrePerson = nrOfPeople;
            Ville = city;
            Rue = street;
            Numero = number;
            CodePostal = zipcode;
            Photo = picture;
            AssuranceObligatoire = insurance;
            isEnabled = enable;
            DisabledDate = disable;
            Latitude = latitude;
            Longitude = longitude;
            DateCreation = creation;
            Pays = ;
            idMembre = member_id;
        }

}
