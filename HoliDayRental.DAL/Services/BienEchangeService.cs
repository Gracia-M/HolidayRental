using HoliDayRental.Common.Repositories;
using HoliDayRental.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HoliDayRental.DAL.Services
{
    public class BienEchangeService : ServiceBase, IBienEchangeRepository<BienEchange>
    {
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM [BienEchange] WHERE [idBien] = @id";
                    SqlParameter p_id = new SqlParameter() { ParameterName = "id", Value = id };
                    command.Parameters.Add(p_id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public BienEchange Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BienEchange> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BienEchange> GetByCapacity(int nbrPerson)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BienEchange> GetByCountry(int country)
        {
            throw new NotImplementedException();
        }

        public BienEchange GetByCountryId(int countryId)
        {
            throw new NotImplementedException();
        }

        public int Insert(BienEchange entity)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO [BienEchange]([titre], [DescCourte], [DescLong],[NombrePerson], [Pays], [Ville], [Rue], [Numero], [CodePostal], [Photo], [Assurance] [isEnabled], [DisabledDate], [Latitude], [Longitude], [idMember], [DateCreation]) OUTPUT [inserted].[idBien] VALUES (@titre, @descr_c, @desr_l, @nrPers @pays, @ville, @rue, @nr, @cp, @foto, @assur, @enable, @disable, @lat, @lon, @idMe, @creation)";
                    SqlParameter p_titre = new SqlParameter { ParameterName = "titre", Value = entity.titre };
                    SqlParameter p_descr_te = new SqlParameter { ParameterName = "descr_c", Value = entity.DescCourte };
                    SqlParameter p_desr_ue = new SqlParameter { ParameterName = "descr_l", Value = entity.DescLong };
                    SqlParameter p_nbr = new SqlParameter { ParameterName = "nrPers", Value = entity.NombrePerson };
                    SqlParameter p_pays = new SqlParameter { ParameterName = "pays", Value = entity.Pays };
                    SqlParameter p_ville = new SqlParameter { ParameterName = "ville", Value = entity.Ville };
                    SqlParameter p_rue = new SqlParameter { ParameterName = "rue", Value = entity.Rue };
                    SqlParameter p_numero = new SqlParameter { ParameterName = "nr", Value = entity.Numero };
                    SqlParameter p_code_Postal = new SqlParameter { ParameterName = "cp", Value = entity.CodePostal };
                    SqlParameter p_photo = new SqlParameter { ParameterName = "foto", Value = entity.Photo };
                    SqlParameter p_assurance = new SqlParameter { ParameterName = "assur", Value = entity.AssuranceObligatoire };
                    SqlParameter p_IsEnable = new SqlParameter { ParameterName = "enable", Value = entity.isEnabled };
                    SqlParameter p_disable = new SqlParameter { ParameterName = "disable", Value = entity.DisabledDate};
                    SqlParameter p_lat= new SqlParameter { ParameterName = "lat", Value = entity.Latitude };
                    SqlParameter p_lon = new SqlParameter { ParameterName = "lon", Value = entity.Longitude};
                    SqlParameter p_idMe = new SqlParameter { ParameterName = "lat", Value = entity.idMembre};
                    SqlParameter p_creation = new SqlParameter { ParameterName = "creation", Value = entity.DateCreation };



                    command.Parameters.Add(p_titre);
                    command.Parameters.Add(p_descr_te);
                    command.Parameters.Add(p_desr_ue);
                    command.Parameters.Add(p_nbr);
                    command.Parameters.Add(p_pays);
                    command.Parameters.Add(p_ville);
                    command.Parameters.Add(p_rue);
                    command.Parameters.Add(p_numero);
                    command.Parameters.Add(p_code_Postal);
                    command.Parameters.Add(p_photo);
                    command.Parameters.Add(p_assurance);
                    command.Parameters.Add(p_IsEnable);
                    command.Parameters.Add(p_disable);
                    command.Parameters.Add(p_lat);
                    command.Parameters.Add(p_lon);
                    command.Parameters.Add(p_idMe);
                    command.Parameters.Add(p_creation);


                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public void Update(int id, BienEchange entity)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE INTO [BienEchange] SET [titre]= @titre, [DescCourte]= @descr_c, [DescLong]= @desr_l, [NombrePerson]= @nrPers, [Pays]= @pays, [Ville]= @ville, [Rue]= @rue, [Numero]= @nr, [CodePostal]= @cp, [Photo]=@foto, [Assurance]=@assur, [isEnabled]=@enable, [DisabledDate]=@disable, [Latitude]= @lat, [Longitude]= @lon, [idMember]= @idMe, [DateCreation]=@creation) WHERE [idBien]= @id ";
                    SqlParameter p_titre = new SqlParameter { ParameterName = "titre", Value = entity.titre };
                    SqlParameter p_descr_te = new SqlParameter { ParameterName = "descr_c", Value = entity.DescCourte };
                    SqlParameter p_desr_ue = new SqlParameter { ParameterName = "descr_l", Value = entity.DescLong };
                    SqlParameter p_nbr = new SqlParameter { ParameterName = "nrPers", Value = entity.NombrePerson };
                    SqlParameter p_pays = new SqlParameter { ParameterName = "pays", Value = entity.Pays };
                    SqlParameter p_ville = new SqlParameter { ParameterName = "ville", Value = entity.Ville };
                    SqlParameter p_rue = new SqlParameter { ParameterName = "rue", Value = entity.Rue };
                    SqlParameter p_numero = new SqlParameter { ParameterName = "nr", Value = entity.Numero };
                    SqlParameter p_code_Postal = new SqlParameter { ParameterName = "cp", Value = entity.CodePostal };
                    SqlParameter p_photo = new SqlParameter { ParameterName = "foto", Value = entity.Photo };
                    SqlParameter p_assurance = new SqlParameter { ParameterName = "assur", Value = entity.AssuranceObligatoire };
                    SqlParameter p_IsEnable = new SqlParameter { ParameterName = "enable", Value = entity.isEnabled };
                    SqlParameter p_disable = new SqlParameter { ParameterName = "disable", Value = entity.DisabledDate };
                    SqlParameter p_lat = new SqlParameter { ParameterName = "lat", Value = entity.Latitude };
                    SqlParameter p_lon = new SqlParameter { ParameterName = "lon", Value = entity.Longitude };
                    SqlParameter p_idMe = new SqlParameter { ParameterName = "lat", Value = entity.idMembre };
                    SqlParameter p_creation = new SqlParameter { ParameterName = "creation", Value = entity.DateCreation };
                    SqlParameter p_id = new SqlParameter() { ParameterName = "id", Value = id };



                    command.Parameters.Add(p_titre);
                    command.Parameters.Add(p_descr_te);
                    command.Parameters.Add(p_desr_ue);
                    command.Parameters.Add(p_nbr);
                    command.Parameters.Add(p_pays);
                    command.Parameters.Add(p_ville);
                    command.Parameters.Add(p_rue);
                    command.Parameters.Add(p_numero);
                    command.Parameters.Add(p_code_Postal);
                    command.Parameters.Add(p_photo);
                    command.Parameters.Add(p_assurance);
                    command.Parameters.Add(p_IsEnable);
                    command.Parameters.Add(p_disable);
                    command.Parameters.Add(p_lat);
                    command.Parameters.Add(p_lon);
                    command.Parameters.Add(p_idMe);
                    command.Parameters.Add(p_creation);
                    command.Parameters.Add(p_id);


                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
