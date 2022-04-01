using AirTiquiciaTry.Models;
using Microsoft.Data.SqlClient;

namespace AirTiquiciaTry.Services
{
    public class AeropuertosDAO : iAeropuertosDataService
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AirTiquiciaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public int Delete(AeropuertosModel aeropuerto)
        {
            throw new NotImplementedException();
        }

        public List<AeropuertosModel> GetAllAeropuertos()
        {
            List<AeropuertosModel> aeropuertosFound = new List<AeropuertosModel>();

            string sqlStatement = "SELECT * FROM dbo.AEROPUERTOS";
            using (SqlConnection connection = new SqlConnection(connectionString))
            { 
            SqlCommand command = new SqlCommand(sqlStatement, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        aeropuertosFound.Add(new AeropuertosModel { cod_iata = (string)reader[0], nombre_aeropuerto = (string)reader[1], cod_pais = (string)reader[2], nombre_pais = (string)reader[3] });
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }
            return aeropuertosFound;
        }

        public AeropuertosModel GetAeropuertoById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(AeropuertosModel aeropuerto)
        {
            throw new NotImplementedException();
        }

        public List<AeropuertosModel> SearchAeropuertos(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public int Update(AeropuertosModel aeropuerto)
        {
            throw new NotImplementedException();
        }
    }
}
