using AirTiquiciaTry.Models;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System;

namespace AirTiquiciaTry.Services
{
    public class VuelosDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AirTiquiciaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<VuelosModel> GetAllVuelos()
        {
            List<VuelosModel> vuelosFound = new List<VuelosModel>();

            string sqlStatement = "SELECT dbo.VUELOS.id_vuelo, dbo.VUELOS.fecha_hora, dbo.VUELOS.es_directo, dbo.VUELOS.id_avion, dbo.VUELOS.origen_iata, origen.nombre_aeropuerto, origen.nombre_pais, dbo.VUELOS.destino_iata, destino.nombre_aeropuerto, destino.nombre_pais, dbo.VUELOS.duracion, dbo.VUELOS.id_capitan, capitan.nombre, capitan.apellido1, dbo.VUELOS.id_copiloto, copiloto.nombre, copiloto.apellido1, dbo.VUELOS.id_tripulante_cabina, tripulante.nombre, tripulante.apellido1, dbo.VUELOS.precio_economica, dbo.VUELOS.precio_primera, dbo.VUELOS.precio_equipaje_kilo FROM dbo.VUELOS INNER JOIN dbo.AEROPUERTOS origen ON dbo.VUELOS.origen_iata = origen.cod_iata INNER JOIN dbo.AEROPUERTOS destino ON dbo.VUELOS.destino_iata = destino.cod_iata INNER JOIN dbo.EMPLEADOS capitan ON dbo.VUELOS.id_capitan = capitan.id_empleado INNER JOIN dbo.EMPLEADOS copiloto ON dbo.VUELOS.id_copiloto = copiloto.id_empleado INNER JOIN dbo.EMPLEADOS tripulante ON dbo.VUELOS.id_tripulante_cabina = tripulante.id_empleado";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                    SqlCommand command = new SqlCommand(sqlStatement, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        vuelosFound.Add(new VuelosModel { id_vuelo = (string)reader[0], fecha_hora = (DateTime)reader[1], es_directo = (string)reader[2], id_avion = (int)reader[3], origen_iata = (string)reader[4], origen_iata_nombre = (string)reader[5], origen_pais = (string)reader[6], destino_iata = (string)reader[7], destino_iata_nombre = (string)reader[8], destino_pais = (string)reader[9], duracion = (string)reader[10], id_capitan = (int)reader[11], nombre_capitan = (string)reader[12], apellido_capitan = (string)reader[13], id_copiloto = (int)reader[14], nombre_copiloto = (string)reader[15], apellido_copiloto = (string)reader[16], id_tripulante_cabina = (int)reader[17], nombre_tripulante_cabina = (string)reader[18], apellido_tripulante_cabina = (string)reader[19], precio_economica = (int)reader[20], precio_primera = (int)reader[21], precio_equipaje_kilo = (int)reader[22] });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return vuelosFound;
        }


        public VuelosModel GetVueloById(string cod)
        {
            VuelosModel foundVuelo = null;

            string sqlStatement = "SELECT dbo.VUELOS.id_vuelo, dbo.VUELOS.fecha_hora, dbo.VUELOS.es_directo, dbo.VUELOS.id_avion, dbo.VUELOS.origen_iata, origen.nombre_aeropuerto, origen.nombre_pais, dbo.VUELOS.destino_iata, destino.nombre_aeropuerto, destino.nombre_pais, dbo.VUELOS.duracion, dbo.VUELOS.id_capitan, capitan.nombre, capitan.apellido1, dbo.VUELOS.id_copiloto, copiloto.nombre, copiloto.apellido1, dbo.VUELOS.id_tripulante_cabina, tripulante.nombre, tripulante.apellido1, dbo.VUELOS.precio_economica, dbo.VUELOS.precio_primera, dbo.VUELOS.precio_equipaje_kilo FROM dbo.VUELOS INNER JOIN dbo.AEROPUERTOS origen ON dbo.VUELOS.origen_iata = origen.cod_iata INNER JOIN dbo.AEROPUERTOS destino ON dbo.VUELOS.destino_iata = destino.cod_iata INNER JOIN dbo.EMPLEADOS capitan ON dbo.VUELOS.id_capitan = capitan.id_empleado INNER JOIN dbo.EMPLEADOS copiloto ON dbo.VUELOS.id_copiloto = copiloto.id_empleado INNER JOIN dbo.EMPLEADOS tripulante ON dbo.VUELOS.id_tripulante_cabina = tripulante.id_empleado WHERE dbo.VUELOS.id_vuelo = @cod";

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
                        foundVuelo = new VuelosModel { id_vuelo = (string)reader[0], fecha_hora = (DateTime)reader[1], es_directo = (string)reader[2], id_avion = (int)reader[3], origen_iata = (string)reader[4], origen_iata_nombre = (string)reader[5], origen_pais = (string)reader[6], destino_iata = (string)reader[7], destino_iata_nombre = (string)reader[8], destino_pais = (string)reader[9], duracion = (string)reader[10], id_capitan = (int)reader[11], nombre_capitan = (string)reader[12], apellido_capitan = (string)reader[13], id_copiloto = (int)reader[14], nombre_copiloto = (string)reader[15], apellido_copiloto = (string)reader[16], id_tripulante_cabina = (int)reader[17], nombre_tripulante_cabina = (string)reader[18], apellido_tripulante_cabina = (string)reader[19], precio_economica = (int)reader[20], precio_primera = (int)reader[21], precio_equipaje_kilo = (int)reader[22] };
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return foundVuelo;
        }

        public String Insert(VuelosModel vuelo)
        {
            string new_id_vuelo = "";
            string sqlStatement = "INSERT INTO dbo.VUELOS (id_vuelo, fecha_hora, es_directo, id_avion, origen_iata, destino_iata, duracion, id_capitan, id_copiloto, id_tripulante_cabina, precio_economica, precio_primera, precio_equipaje_kilo) VALUES (@id_vuelo, @fecha_hora, @es_directo, @id_avion, @origen_iata, @destino_iata, @duracion, @id_capitan, @id_copiloto, @id_tripulante_cabina, @precio_economica, @precio_primera, @precio_equipaje_kilo)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@id_vuelo", vuelo.id_vuelo);
                command.Parameters.AddWithValue("@fecha_hora", vuelo.fecha_hora);
                command.Parameters.AddWithValue("@es_directo", vuelo.es_directo);
                command.Parameters.AddWithValue("@id_avion", vuelo.id_avion);
                command.Parameters.AddWithValue("@origen_iata", vuelo.origen_iata);
                command.Parameters.AddWithValue("@destino_iata", vuelo.destino_iata);
                command.Parameters.AddWithValue("@duracion", vuelo.duracion);
                command.Parameters.AddWithValue("@id_capitan", vuelo.id_capitan);
                command.Parameters.AddWithValue("@id_copiloto", vuelo.id_copiloto);
                command.Parameters.AddWithValue("@id_tripulante_cabina", vuelo.id_tripulante_cabina);
                command.Parameters.AddWithValue("@precio_economica", vuelo.precio_economica);
                command.Parameters.AddWithValue("@precio_primera", vuelo.precio_primera);
                command.Parameters.AddWithValue("@precio_equipaje_kilo", vuelo.precio_equipaje_kilo);
                try
                {
                    connection.Open();
                    new_id_vuelo = (string)command.ExecuteScalar();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return new_id_vuelo;
        }

        /*
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
        */

    }

}
