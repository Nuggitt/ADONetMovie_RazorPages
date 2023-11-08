
using ADONetMovie_RazorPages.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ADONetMovie_RazorPages.Services.ADOStudioService
{
    public class AdonetStudioService
    {
        private IConfiguration configuration { get; }
        string connectionString;

        public AdonetStudioService() { }
        public AdonetStudioService(IConfiguration config)
        {
            configuration = config;
            connectionString = configuration.GetConnectionString("CinemaConnection");
        }
        public List<Studio> GetAllStudios()
        {
            List<Studio> lst = new List<Studio>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                string sql = "Select * From Studio";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Studio studio = new Studio();
                        studio.Id = Convert.ToInt32(dataReader["Id"]);
                        studio.Name = Convert.ToString(dataReader["Name"]);
                        studio.Hqcity = Convert.ToString(dataReader["Hqcity"]);
                        studio.NoOfEmployees = Convert.ToInt32(dataReader["NoOfEmployees"]);
                        lst.Add(studio);
                    }
                }
            }
            return lst;
        }

        public Studio CreateStudio(Studio studio)
        {
            List<Studio> studios = new List<Studio>();
            string sql = "INSERT INTO dbo.Studio (Id, Name, HQCity, NoOfEmployees) VALUES(@Id, @Name, @HQCity, @NoOfEmployees)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    command.Parameters.AddWithValue("@Id", studio.Id);
                    command.Parameters.AddWithValue("@Name", studio.Name);
                    command.Parameters.AddWithValue("@HQCity", studio.Hqcity);
                    command.Parameters.AddWithValue("@NoOfEmployees", studio.NoOfEmployees);
                    studios.Add(studio);

                    int numberOfRowsAffected = command.ExecuteNonQuery();


                }

            }
            return studio;

        }

        public Studio DeleteStudio(Studio studio)
        {

            string sql = "DELETE FROM dbo.Studio WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    command.Parameters.AddWithValue("@Id", studio.Id);
                    

                    command.ExecuteNonQuery();
                }
            }
            return studio;
            
        }

        public Studio GetStudio(int id)
        {
            List<Studio> studios = new List<Studio>();
            Studio studio = new Studio();
            string sql = "SELECT * FROM dbo.studio WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        studio.Id = dataReader.GetInt32(0);
                        studio.Name = Convert.ToString(dataReader["Name"]);
                        studio.Hqcity = Convert.ToString(dataReader["Hqcity"]);
                        studio.NoOfEmployees = Convert.ToInt32(dataReader["NoOfEmployees"]);
                        studios.Add(studio);
                    }
                }
            }

            return studio;
        }

        public Studio UpdateStudio(Studio studio)
        {
            string queryString = $"Update dbo.Studio Set Name = @Name, HQCity = @HQCity, NoOfEmployees = @NoOfEmployees Where Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    // Open the connection
                    connection.Open();

                    // Add parameters with the correct names and values
                    command.Parameters.AddWithValue("@Id", studio.Id);
                    command.Parameters.AddWithValue("@Name", studio.Name);
                    command.Parameters.AddWithValue("@HQCity", studio.Hqcity);
                    command.Parameters.AddWithValue("@NoOfEmployees", studio.NoOfEmployees);

                    // Execute the query and get the number of rows affected
                    command.ExecuteNonQuery();


                }

            }
            return studio;
        }

    }


}

