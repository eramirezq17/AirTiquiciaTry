using AirTiquiciaTry.Models;
using Microsoft.Data.SqlClient;

namespace AirTiquiciaTry.Services
{
    public class AeropuertosDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AirTiquiciaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public String Delete(AeropuertosModel aeropuerto)
        {
            string new_cod_iata = "000";
            string sqlStatement = "DELETE FROM dbo.AEROPUERTOS WHERE cod_iata = @cod_iata";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@cod_iata", aeropuerto.cod_iata);
                try
                {
                    connection.Open();
                    new_cod_iata = (string)command.ExecuteScalar();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return new_cod_iata;
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

        public AeropuertosModel GetAeropuertoById(string cod)
        {
            AeropuertosModel foundAeropuerto = null;

            string sqlStatement = "SELECT * FROM dbo.AEROPUERTOS WHERE cod_iata = @cod";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@cod", cod);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundAeropuerto = new AeropuertosModel { cod_iata = (string)reader[0], nombre_aeropuerto = (String)reader[1], cod_pais = (String)reader[2], nombre_pais = (String)reader[3] };
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return foundAeropuerto;
        }

        public String Insert(AeropuertosModel aeropuerto)
        {
            string new_cod_iata = "000";
            string sqlStatement = "INSERT INTO dbo.AEROPUERTOS (cod_iata, nombre_aeropuerto, cod_pais, nombre_pais) VALUES (@cod_iata, @nombre_aeropuerto, @cod_pais, @nombre_pais)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@cod_iata", aeropuerto.cod_iata);
                command.Parameters.AddWithValue("@nombre_aeropuerto", aeropuerto.nombre_aeropuerto);
                command.Parameters.AddWithValue("@cod_pais", aeropuerto.cod_pais);
                command.Parameters.AddWithValue("@nombre_pais", aeropuerto.nombre_pais);

                try
                {
                    connection.Open();
                    new_cod_iata = (string)command.ExecuteScalar();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return new_cod_iata;
        }

        public List<AeropuertosModel> SearchAeropuertos(string searchTerm)
        {
            List<AeropuertosModel> foundAeropuertos = new List<AeropuertosModel>();
            string sqlStatement = "SELECT * FROM dbo.AEROPUERTOS WHERE nombre_aeropuerto LIKE @nombre_aeropuerto";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@nombre_aeropuerto", '%' + searchTerm + '%');
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundAeropuertos.Add(new AeropuertosModel { cod_iata = (string)reader[0], nombre_aeropuerto = (string)reader[1], cod_pais = (string)reader[2], nombre_pais = (string)reader[3] });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return foundAeropuertos;
        }

        public String Update(AeropuertosModel aeropuerto)
        {
            string new_cod_iata = "000";
            string sqlStatement = "UPDATE dbo.AEROPUERTOS SET nombre_aeropuerto = @nombre_aeropuerto, cod_pais = @cod_pais, nombre_pais = @nombre_pais WHERE cod_iata = @cod_iata";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@cod_iata", aeropuerto.cod_iata);
                command.Parameters.AddWithValue("@nombre_aeropuerto", aeropuerto.nombre_aeropuerto);
                command.Parameters.AddWithValue("@cod_pais", aeropuerto.cod_pais);
                command.Parameters.AddWithValue("@nombre_pais", aeropuerto.nombre_pais);

                try
                {
                    connection.Open();
                    new_cod_iata = (string)command.ExecuteScalar();
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return new_cod_iata;
        }
    }
}
