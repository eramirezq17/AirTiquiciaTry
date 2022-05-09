using AirTiquiciaTry.Models;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace AirTiquiciaTry.Services
{
    public class ReservasDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AirTiquiciaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public int InsertPasajero(ViewModelReserva infoReserva)
        {
            int new_id_pasajero = -1;
            string sqlStatement = "IF NOT EXISTS (SELECT * FROM dbo.PASAJEROS WHERE dbo.PASAJEROS.id = @id) INSERT INTO dbo.PASAJEROS (id, nombre, apellido1, apellido2, fecha_nac, correo, telefono) VALUES (@id, @nombre, @apellido1, @apellido2, @fecha_nac, @correo, @telefono) ELSE UPDATE dbo.PASAJEROS SET nombre = @nombre, apellido1 = @apellido1, apellido2 = @apellido2, fecha_nac = @fecha_nac, correo = @correo, telefono = @telefono WHERE dbo.PASAJEROS.id = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@id", infoReserva.id_pasajero);
                command.Parameters.AddWithValue("@nombre", infoReserva.nombre);
                command.Parameters.AddWithValue("@apellido1", infoReserva.apellido1);
                command.Parameters.AddWithValue("@apellido2", infoReserva.apellido2);
                command.Parameters.AddWithValue("@fecha_nac", infoReserva.fecha_nac);
                command.Parameters.AddWithValue("@correo", infoReserva.correo);
                command.Parameters.AddWithValue("@telefono", infoReserva.telefono);
                try
                {
                    connection.Open();
                    new_id_pasajero = Convert.ToInt32(command.ExecuteScalar());

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
            return infoReserva.id_pasajero;
        }

        public ViewModelReserva GetPasajeroById(int id)
        {
            ViewModelReserva foundPasajero = null;

            string sqlStatement = "SELECT * FROM dbo.PASAJEROS WHERE id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@id", id);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundPasajero = new ViewModelReserva { id_pasajero = (int)reader[0], nombre = (string)reader[1], apellido1 = (String)reader[2], apellido2 = (String)reader[3], fecha_nac = (DateTime)reader[4], correo = (String)reader[5], telefono = (String)reader[6] };
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
            return foundPasajero;
        }

        public string GenerarNumReserva(int length = 8)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var num_reserva = new string(Enumerable.Repeat(chars, length)
                .Select(s =>s[random.Next(s.Length)]).ToArray());
            return num_reserva;
        }

      

        public string AddReserva(ViewModelReserva infoReserva)
        {
            int new_id_reserva = -1;
            string sqlStatement = "INSERT INTO dbo.RESERVAS (id, id_pasajero, id_vuelo, cant_maletas_extra, asiento) VALUES (@id, @id_pasajero, @id_vuelo, @cant_maletas_extra, @asiento)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@id", infoReserva.id);
                command.Parameters.AddWithValue("@id_pasajero", infoReserva.id_pasajero);
                command.Parameters.AddWithValue("@id_vuelo", infoReserva.id_vuelo);
                command.Parameters.AddWithValue("@cant_maletas_extra", infoReserva.cant_maletas_extra);
                command.Parameters.AddWithValue("@asiento", infoReserva.asiento);
                try
                {
                    connection.Open();
                    new_id_reserva = Convert.ToInt32(command.ExecuteScalar());

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
            return infoReserva.id;
        }

        public void confirmationEmail(ViewModelReserva infoReserva)
        {
            //crear el mensaje que va a contener los datos. 
            MimeMessage message = new MimeMessage();
            //agregar direccion que envia
            message.From.Add(new MailboxAddress("AirTiquicia", "ERQDummy@gmail.com"));
            //direccion de envio
            message.To.Add(MailboxAddress.Parse(infoReserva.correo));
            //agregar subject
            message.Subject = "Itinerario AirTiquicia. Reserva " +infoReserva.id +" confirmada.";
            message.Body = new TextPart("plain")
            {
                Text = @"Mi itinerario AirTiquicia!

                    Felicidades " + infoReserva.nombre + ". Has reservado satisfactoriamente el asiento " + infoReserva.asiento + " en el vuelo " + infoReserva.id_vuelo + @". 
                    Fecha y Hora de Salida: " + infoReserva.fechaSalida + @".
                    Salida: " + infoReserva.fullOrigen + @".
                    Destino: " + infoReserva.fullDestino + @".
                    Cantidad de maletas adicionales: " + infoReserva.cant_maletas_extra + @".
                    Total a pagar: $" + infoReserva.total + @".
                   

                    Favor llegar al aeropuerto al menos 3 horas antes de la hora de salida si es un vuelo internacional, o 2 horas antes si es un vuelo local para completar el proceso de Check-in.
                    

                    Gracias por volar con AirTiquicia!"
            };

            SmtpClient client = new SmtpClient();

            try
            {
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate("ERQDummy@gmail.com", "W3FyRzywCMM4Rse");
                client.Send(message);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }

        public void confirmationEmailRedondo(ViewModelReserva infoReserva)
        {
            //crear el mensaje que va a contener los datos. 
            MimeMessage message = new MimeMessage();
            //agregar direccion que envia
            message.From.Add(new MailboxAddress("AirTiquicia", "ERQDummy@gmail.com"));
            //direccion de envio
            message.To.Add(MailboxAddress.Parse(infoReserva.correo));
            //agregar subject
            message.Subject = "Itinerario AirTiquicia. Reserva " + infoReserva.id + " confirmada.";
            message.Body = new TextPart("plain")
            {
                Text = @"Mi itinerario AirTiquicia!

                    Felicidades " + infoReserva.nombre + ". Has reservado satisfactoriamente tu viaje ida y vuelta desde " + infoReserva.fullOrigen + " hacia " + infoReserva.fullDestino + @"
                    Asiento " + infoReserva.asiento + " en el vuelo " + infoReserva.id_vuelo + @". 
                    Asiento " + infoReserva.asientoRegreso + " en el vuelo " + infoReserva.id_vuelo_regreso + @".
                    Fecha y Hora de Salida: " + infoReserva.fechaSalida + @".
                    Fecha y Hora de Regreso: " + infoReserva.fechaRegreso + @".
                    Salida: " + infoReserva.fullOrigen + @".
                    Destino: " + infoReserva.fullDestino + @".
                    Cantidad de maletas adicionales: " + infoReserva.cant_maletas_extra + @".
                    Total a pagar: $" + infoReserva.total + @".
                   

                    Favor llegar al aeropuerto al menos 3 horas antes de la hora de salida si es un vuelo internacional, o 2 horas antes si es un vuelo local para completar el proceso de Check-in.
                    

                    Gracias por volar con AirTiquicia!"
            };

            SmtpClient client = new SmtpClient();

            try
            {
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate("ERQDummy@gmail.com", "W3FyRzywCMM4Rse");
                client.Send(message);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}
