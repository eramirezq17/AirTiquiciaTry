using AirTiquiciaTry.Models;
using Microsoft.Data;
using Microsoft.Data.SqlClient;

namespace AirTiquiciaTry.Services
{
    public class AvionesDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AirTiquiciaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<AvionesModel> GetAllAviones()
        {
            List<AvionesModel> avionesFound = new List<AvionesModel>();

            string sqlStatement = "SELECT dbo.AVIONES.id_avion, dbo.AVIONES.id_tipo_avion, dbo.AVIONES.marca, dbo.AVIONES.modelo, dbo.TIPOS_AVION.nombre FROM dbo.AVIONES INNER JOIN dbo.TIPOS_AVION ON dbo.AVIONES.id_tipo_avion=dbo.TIPOS_AVION.id_tipo";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                       avionesFound.Add(new AvionesModel { id_avion = (int)reader[0], id_tipo_avion = (int)reader[1], marca = (string)reader[2], modelo = (string)reader[3], nombre_tipo_avion = (string)reader[4] });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return avionesFound;
        }
        
        public int Delete(AvionesModel avion)
        {
            int new_id_avion = -1;
            string sqlStatement = "DELETE FROM dbo.AVIONES WHERE id_avion = @id_avion";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@id_avion", avion.id_avion);
                try
                {
                    connection.Open();
                    new_id_avion = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return new_id_avion;
        }

       
        
        public AvionesModel GetAvionById(int cod)
        {
            AvionesModel foundAvion = null;

            string sqlStatement = "SELECT dbo.AVIONES.id_avion, dbo.AVIONES.id_tipo_avion, dbo.AVIONES.marca, dbo.AVIONES.modelo, dbo.TIPOS_AVION.nombre FROM dbo.AVIONES INNER JOIN dbo.TIPOS_AVION ON dbo.AVIONES.id_tipo_avion=dbo.TIPOS_AVION.id_tipo WHERE id_avion = @cod";

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
                        foundAvion = new AvionesModel { id_avion = (int)reader[0], id_tipo_avion = (int)reader[1], marca = (String)reader[2], modelo = (String)reader[3], nombre_tipo_avion = (String)reader[4] };
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return foundAvion;
        }

        
        public int Insert(AvionesModel avion)
        {
            int new_id_avion = -1;
            string sqlStatement = "INSERT INTO dbo.AVIONES (id_tipo_avion, marca, modelo) VALUES (@id_tipo_avion, @marca, @modelo)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@id_tipo_avion", avion.id_tipo_avion);
                command.Parameters.AddWithValue("@marca", avion.marca);
                command.Parameters.AddWithValue("@modelo", avion.modelo);

                try
                {
                    connection.Open();
                    new_id_avion = Convert.ToInt32 (command.ExecuteScalar());

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return new_id_avion;
        }
        
        public List<AvionesModel> SearchAviones(string searchTerm)
        {
            List<AvionesModel> foundAviones = new List<AvionesModel>();
            string sqlStatement = "SELECT dbo.AVIONES.id_avion, dbo.AVIONES.id_tipo_avion, dbo.AVIONES.marca, dbo.AVIONES.modelo, dbo.TIPOS_AVION.nombre FROM dbo.AVIONES INNER JOIN dbo.TIPOS_AVION ON dbo.AVIONES.id_tipo_avion=dbo.TIPOS_AVION.id_tipo WHERE marca LIKE @marca";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@marca", '%' + searchTerm + '%');
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundAviones.Add(new AvionesModel { id_avion = (int)reader[0], id_tipo_avion = (int)reader[1], marca = (String)reader[2], modelo = (String)reader[3], nombre_tipo_avion = (String)reader[4] });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return foundAviones;
        }
        
        public int Update(AvionesModel avion)
        {
            int new_id_avion = -1;
            string sqlStatement = "UPDATE dbo.AVIONES SET id_tipo_avion = @id_tipo_avion, marca = @marca, modelo = @modelo WHERE id_avion = @id_avion";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@id_avion", avion.id_avion);
                command.Parameters.AddWithValue("@id_tipo_avion", avion.id_tipo_avion);
                command.Parameters.AddWithValue("@marca", avion.marca);
                command.Parameters.AddWithValue("@modelo", avion.modelo);

                try
                {
                    connection.Open();
                    new_id_avion = Convert.ToInt32 (command.ExecuteScalar());
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return new_id_avion;
        }
        

    }

}
