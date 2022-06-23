
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
        public Pays  Pays { get; set; }
        public int Pays_Id { get; set; }
        public string Telephone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public IEnumerable<Pays> LesPays { get; set; }

        public Membre(int id, string nom, string prenom, string email, Pays pays, string phone, string login, string password)
        {
            idMembre = id;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Pays = pays;
            if (pays == null) throw new ArgumentNullException(nameof(Pays_Id));
            Pays_Id = pays.idPays;
            Telephone = phone;
            Login = login;
            Password = password;
        }

        public Membre(int id, string nom, string prenom, string email, int paysId, string phone, string login, string password)
        {
            idMembre = id;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Pays_Id = paysId;
            Telephone = phone;
            Login = login;
            Password = password;
        }
    }

}
