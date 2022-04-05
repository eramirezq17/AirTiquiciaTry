using AirTiquiciaTry.Models;
using Microsoft.Data.SqlClient;

namespace AirTiquiciaTry.Services
{
    public class LoginDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AirTiquiciaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public UsuariosModel ValidateCredentials(string username, string password)
        {
            UsuariosModel usuarioFound = null;

            string sqlStatement = "SELECT * FROM dbo.USUARIOS  WHERE username = @username AND password=@password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        usuarioFound = new UsuariosModel { username = (string)reader[0], password = (string)reader[1], nombre = (string)reader[2], apellido1 = (string)reader[3], apellido2 = (String)reader[4], email = (string)reader[5], rol = (string)reader[6] };
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return usuarioFound;
        }

    }
}
