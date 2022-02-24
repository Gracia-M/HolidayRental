using HoliDayRental.Common.Repositories;
using HoliDayRental.DAL.Entities;
using HoliDayRental.DAL.Handlers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HoliDayRental.DAL.Services
{
    public class OptionsService : ServiceBase, IOptionsRepository<Options>
    {
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM [Options] WHERE [idOption] = @id";

                    SqlParameter p_id = new SqlParameter("id", id);
                    command.Parameters.Add(p_id);
                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
        }

        public Options Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idOption], [Libelle] FROM [Options] WHERE [idOption] = @id";

                    SqlParameter p_id = new SqlParameter("id", id);
                    command.Parameters.Add(p_id);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read()) return Mapper.ToOptions(reader);
                    return null;
                }
            }
        }

        public IEnumerable<Options> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idOption], [Libelle] FROM [Options]";

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) yield return Mapper.ToOptions(reader);
                }
            }
        }

        public IEnumerable<Options> GetByCriteria(int criteria)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idOption], [Libelle] FROM [Options] WHERE Criteria([Libelle]) = @critere";

                    SqlParameter p_criteria = new SqlParameter("critere", criteria);
                    command.Parameters.Add(p_criteria);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) yield return Mapper.ToOptions(reader);
                }
            }
        }

        public Options GetByOptionsId(int optionsId)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [Options].[idOption], [Valeur] FROM [Options] JOIN [OptionsBien] ON [Options].[idOption] = [idOption] WHERE [OptionsBien].[idOption] = @id";
                    //Parameters...
                    SqlParameter p_id = new SqlParameter("id", optionsId);
                    command.Parameters.Add(p_id);
                    connection.Open();
                    //Choose Execution method
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read()) return Mapper.ToOptions(reader);
                    return null;
                }
            }
        }

        public IEnumerable<Options> GetByValue(int value)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idOption], [Libelle] FROM [Options] WHERE Criteria([Libelle]) = @valeur";

                    SqlParameter p_criteria = new SqlParameter("valeur", value);
                    command.Parameters.Add(p_criteria);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) yield return Mapper.ToOptions(reader);
                }
            }
        }

        public int Insert(Options entity)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO [Options]([Libelle]) OUTPUT [inserted].[idOption] VALUES (@libe)";
                    SqlParameter p_libelle = new SqlParameter { ParameterName = "nom", Value = entity.Libelle};
                    command.Parameters.Add(p_libelle);
                  
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public void Update(int id, Options entity)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE [Options] SET [Libelle] = @libe WHERE [idOption] = @id";
                    //Parameters...
                    SqlParameter p_libelle = new SqlParameter("libe", entity.Libelle);
                    command.Parameters.Add(p_libelle);
                    
                    connection.Open();
                    //Choose Execution method
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
