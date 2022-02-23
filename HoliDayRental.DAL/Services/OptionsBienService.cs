using HoliDayRental.Common.Repositories;
using HoliDayRental.DAL.Entities;
using HoliDayRental.DAL.Handlers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HoliDayRental.DAL.Services
{
    public class OptionsBienService : ServiceBase, IOptionsBienRepository<OptionsBien>
    {
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM [OptionsBien] WHERE [idOption] = @id";
             
                    SqlParameter p_id = new SqlParameter("id", id);
                    command.Parameters.Add(p_id);
                    connection.Open();
       
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<OptionsBien> Get(string value)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idOption], [idBien], [Valeur] FROM [OptionsBien] WHERE [Valeur]= @valeur";
                    
                    SqlParameter p_valeur = new SqlParameter("valeur", value);
                    command.Parameters.Add(p_valeur);
                    connection.Open();
                   
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) yield return Mapper.ToOptionsBien(reader);
                }
            }
        }

        public OptionsBien Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idOption], [idBien], [Valeur] FROM [OptionsBien] WHERE [idOption] = @id";
        
                    SqlParameter p_id = new SqlParameter("id", id);
                    command.Parameters.Add(p_id);
                    connection.Open();
                 
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read()) return Mapper.ToOptionsBien(reader);
                    return null;
                }
            }
        }

        public IEnumerable<OptionsBien> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idOption], [idBien], [Valeur] FROM [OptionsBien]";
                   
                    connection.Open();
                    
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) yield return Mapper.ToOptionsBien(reader);
                }
            }
        }

        public IEnumerable<OptionsBien> GetByBienId(int bien_id)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idOption], [idBien], [Valeur] FROM [OptionsBien] FROM [OptionsBien] WHERE [idBien]= @bien";
                  
                    SqlParameter p_bien = new SqlParameter("bien", bien_id);
                    command.Parameters.Add(p_bien);
                    connection.Open();
                    
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) yield return Mapper.ToOptionsBien(reader);
                }
            }
        }

        public IEnumerable<OptionsBien> GetByOptionId(int option_id)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idOption], [idBien], [Valeur] FROM [OptionsBien] WHERE [idOption]= @option";
                 
                    SqlParameter p_option = new SqlParameter("option", option_id);
                    command.Parameters.Add(p_option);
                    connection.Open();
                   
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) yield return Mapper.ToOptionsBien(reader);
                }
            }
        }


        public int Insert(OptionsBien entity)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO [OptionsBien]([Valeur]) OUTPUT [inserted].[idOption] VALUES ( @valeur)";
                    command.CommandText = "INSERT INTO [OptionsBien]([Valeur]) OUTPUT [inserted].[idBien] VALUES ( @valeur)";
                    SqlParameter p_valeur = new SqlParameter("valeur", entity.Valeur);

                    connection.Open();
                    return (int)command.ExecuteScalar();
                }

            }
        }

        public void Update(int id, OptionsBien entity)
        {
                using (SqlConnection connection = new SqlConnection(_connString))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "UPDATE [OptionsBien] SET [Valeur] = @valeur WHERE [idOption] = @id1 OR [idBien] = @id2";
                    
                        SqlParameter p_valeur1 = new SqlParameter("valeur", entity.idOption);
                        SqlParameter p_valeur2 = new SqlParameter("valeur", entity.idBien);

                        command.Parameters.Add(p_valeur1);
                        SqlParameter p_id = new SqlParameter("id1", id);
                        command.Parameters.Add(p_valeur2);
                        SqlParameter p_id1 = new SqlParameter("id2", id);
                        command.Parameters.Add(p_id1);
                        connection.Open();
                        
                        command.ExecuteNonQuery();
                    }
                }
            }
    }
}
