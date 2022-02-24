using B = HoliDayRental.BLL.Entities;
using D = HoliDayRental.DAL.Entities;

namespace HoliDayRental.BLL.Handlers
{
    public static class Mapper
    {
        public static B.BienEchange ToBLL(this D.BienEchange entity)
        {
            if (entity == null) return null;
            return new B.BienEchange(
                entity.idBien,
                entity.titre,
                entity.DescCourte,
                entity.DescLong,
                entity.NombrePerson,
                entity.Pays,
                entity.Ville,
                entity.Rue,
                entity.Numero,
                entity.CodePostal,
                entity.Photo,
                entity.AssuranceObligatoire,
                entity.Latitude,
                entity.Longitude,
                entity.idMembre
                );
        }
        public static D.BienEchange ToBLL(this B.BienEchange entity)
        {
            if (entity == null) return null;
            return new D.BienEchange
            {
                idBien = entity.idBien,
                titre = entity.titre,
                DescCourte = entity.DescCourte,
                DescLong = entity.DescLong,
                NombrePerson = entity.NombrePerson,
                Pays = entity.Pays,
                Ville = entity.Ville,
                Rue = entity.Rue,
                Numero = entity.Numero,
                CodePostal = entity.CodePostal,
                Photo = entity.Photo,
                AssuranceObligatoire = entity.AssuranceObligatoire,
                Latitude = entity.Latitude,
                Longitude = entity.Longitude,
                idMembre = entity.idMembre,
            };

        }
        public static B.Membre ToBLL(this D.Membre entity)
        {
            if (entity == null) return null;
            return new B.Membre(
                entity.idMembre,
                entity.Nom,
                entity.Prenom,
                entity.Email,
                entity.Pays,
                entity.Telephone,
                entity.Login,
                entity.Password

            );
        }

        public static D.Membre ToBLL(this B.Membre entity)
        {
            if (entity == null) return null;
            return new D.Membre
            {
                idMembre = entity.idMembre,
                Nom = entity.Nom,
                Prenom = entity.Prenom,
                Email = entity.Email,
                Pays = entity.Pays,
                Telephone = entity.Telephone,
                Login = entity.Login,
                Password = entity.Password
            };
        }
        public static B.OptionsBien ToBLL(this D.OptionsBien entity)
        {
            if (entity == null) return null;
            return new B.OptionsBien(
                entity.Valeur  
                );
        }
        public static D.OptionsBien ToDAL(this B.OptionsBien entity)
        {
            if (entity == null) return null;
            return new D.OptionsBien
            {
                Valeur = entity.Valeur,
 
            };
        }
        public static B.Options ToBLL(this D.Options entity)
        {
            if (entity == null) return null;
            return new B.Options(
                entity.idOption,
                entity.Libelle
                
                );
        }
        public static D.Options ToDAL(this B.Options entity)
        {
            if (entity == null) return null;
            return new D.Options
            {
                idOption = entity.idOption,
                Libelle = entity.Libelle
             
            };
        }

        public static B.Pays ToBLL(this D.Pays entity)
        {
            if (entity == null) return null;
            return new B.Pays(
                entity.idPays,
                entity.Libelle);
        }

        public static D.Pays ToDAL(this B.Pays entity)
        {
            if (entity == null) return null;
            return new D.Pays
            {
                idPays = entity.idPays,
                Libelle = entity.Libelle
            };
        }
    }
}
