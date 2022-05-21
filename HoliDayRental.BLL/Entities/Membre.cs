
using System;
using System.Collections.Generic;
using System.Text;

namespace HoliDayRental.BLL.Entities
{
    public class Membre
    {
        public int idMembre { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public int Pays_Id { get; set; }
        public Pays Country { get; set; }
        public string Telephone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }


        public IEnumerable<Pays> Countries { get; set; }

        public Membre(int id, string nom, string prenom, string email, Pays country, string phone, string login, string password)
        {
            idMembre = id;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Country = country;
            if (country == null) throw new ArgumentNullException(nameof(Pays_Id));
            Pays_Id = country.idPays;
            Telephone = phone;
            Login = login;
            Password = password;
        }

        public Membre(int id, string nom, string prenom, string email, int pays_id, string telephone, string login, string password)
        {
            idMembre = id;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Pays_Id = pays_id;
            Telephone = telephone;
            Login = login;
            Password = password;
        }
    }
}
