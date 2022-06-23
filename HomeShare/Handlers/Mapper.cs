using HoliDayRental.BLL.Entities;
using HoliDayRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B = HoliDayRental.BLL.Entities;
using M = HoliDayRental.Models;



namespace HoliDayRental.Handlers
{
    public static class Mapper
    {
        public static BienEchangeList ToListItem(this BienEchange entity)
        {
            if (entity == null) return null;
            return new BienEchangeList
            {
                idBien = entity.idBien,
                titre = entity.titre,
                DescCourte = entity.DescCourte,
                idPays = entity.Pays_Id,
                NombrePerson = entity.NombrePerson,
                Photo = entity.Photo,
                Ville = entity.Ville
            };
        }

        public static BienEchangeDetails ToDetails(this BienEchange entity)
        {
            if (entity == null) return null;
            return new BienEchangeDetails
            {
                idBien = entity.idBien,
                titre = entity.titre,
                DescCourte = entity.DescCourte,
                DescLong = entity.DescLong,
                NombrePerson = entity.NombrePerson,
                idPays = entity.Pays_Id,
                Ville = entity.Ville,
                Rue = entity.Rue,
                Numero = entity.Numero,
                CodePostal = entity.CodePostal,
                Photo = entity.Photo,
                AssuranceObligatoire = entity.AssuranceObligatoire,
                Latitude = entity.Latitude,
                Longitude = entity.Longitude,
                idMembre = entity.Membre.idMembre,
            };
        }

        public static M.Pays ToDetails(this B.Pays entity)
        {
            if (entity == null) return null;
            return new M.Pays
            {
                idPays = entity.idPays,
                Libelle = entity.Libelle
            };
        }

        public static MembreList ToListItem(this Membre entity)
        {
            if (entity == null) return null;
            return new MembreList
            {
                idMembre = entity.idMembre,
                Nom = entity.Nom,
                Prenom = entity.Prenom,
                Email = entity.Email,
                idPays = entity.Pays_Id,
                Telephone = entity.Telephone
            };
        }

        public static MembreDetails ToDetails(this Membre entity)
        {
            if (entity == null) return null;
            return new MembreDetails
            {
                idMembre = entity.idMembre,
                Nom = entity.Nom,
                Prenom = entity.Prenom,
                Email = entity.Email,
                idPays = entity.Pays_Id,
                Telephone = entity.Telephone,
                Login = entity.Login,
                Password = entity.Password
            };
        }

        public static MembreEdit ToEdit(this Membre entity)
        {
            if (entity == null) return null;
            return new MembreEdit
            {
                Nom = entity.Nom,
                Prenom = entity.Prenom,
                Email = entity.Email,
                idPays = entity.Pays_Id,
                Telephone = entity.Telephone,
                Login = entity.Login,
                Password = entity.Password
            };
        }

        public static MembreDelete ToDelete(this Membre entity)
        {
            if (entity == null) return null;
            return new MembreDelete
            {
                Nom = entity.Nom,
                Prenom = entity.Prenom,
                Login = entity.Login
            };
        }
    }
}
