using B = HoliDayRental.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
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
                entity.isEnabled,
                entity.DisabledDate,
                entity.Latitude,
                entity.Longitude,

                );
        }
        public static D.Bien ToBLL(this B.Bien entity)
        {
            if (entity == null) return null;
            return new D.Bien
            {
                idBien = entity.idBien,
                titre = entity.titre,
                descriptionCourte = entity.descriptionCourte,
                descriptionLongue = entity.descriptionLongue,
                Pays = entity.Pays,
                Ville = entity.Ville,
                Rue = entity.Rue,
                Numero = entity.Numero,
                CodePostal = entity.CodePostal,
                Photo = entity.Photo,
                nbrSalleBains = entity.nbrSalleBains,
                nbrWC = entity.nbrWC,
                dateDebut = entity.dateDebut,
                dateFin = entity.dateFin
            };

        }
    }
}
