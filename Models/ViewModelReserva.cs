using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AirTiquiciaTry.Models
{
    public class ViewModelReserva
    {
        [Key]
        [DisplayName("Número de Reserva")]
        [Required(ErrorMessage = "El numero de reserva es requerido")]
        public string id { get; set; }

        [DisplayName("Número de vuelo")]
        [Required(ErrorMessage = "Campo requerido")]
        public string id_vuelo { get; set; }

        [DisplayName("Número de vuelo regreso")]
        [Required(ErrorMessage = "Campo requerido")]
        public string id_vuelo_regreso { get; set; }

        [DisplayName("Código de Aeropuerto Origen")]
        [Required(ErrorMessage = "Campo requerido")]
        public string origen_iata { get; set; }

        [DisplayName("Código de Aeropuerto Destino")]
        [Required(ErrorMessage = "Campo requerido")]
        public string destino_iata { get; set; }

        [DisplayName("Fecha de Salida")]
        [Required(ErrorMessage = "Campo requerido")]
        public DateTime fechaSalida { get; set; }

        [DisplayName("Fecha de Regreso")]
        [Required(ErrorMessage = "Campo requerido")]
        public DateTime fechaRegreso { get; set; }

        [DisplayName("Identificación del Pasajero")]
        [Required(ErrorMessage = "Campo requerido")]
        public int id_pasajero { get; set; }

        [DisplayName("Nombre del Pasajero")]
        [Required(ErrorMessage = "Campo requerido")]
        public string nombre { get; set; }

        [DisplayName("Primer Apellido")]
        [Required(ErrorMessage = "Campo requerido")]
        public string apellido1 { get; set; }

        [DisplayName("Segundo Apellido")]
        [Required(ErrorMessage = "Campo requerido")]
        public string apellido2 { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayName("Fecha de nacimiento")]
        [Required(ErrorMessage = "Campo requerido")]
        public DateTime fecha_nac { get; set; }

        [DisplayName("Correo Electrónico")]
        [Required(ErrorMessage = "Campo requerido")]
        [RegularExpression(@"^[\w-_]+(\.[\w!#$%'*+\/=?\^`{|}]+)*@((([\-\w]+\.)+[a-zA-Z]{2,20})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessage = "Formato de correo invalido")]
        public string correo { get; set; }

        [DisplayName("Número de teléfono")]
        [Required(ErrorMessage = "Campo requerido")]
        public string telefono { get; set; }

        [DisplayName("Nombre Aeropuerto Origen")]
        [Required(ErrorMessage = "El nombre del aeropuerto es requerido")]
        public string nombre_aeropuerto_origen { get; set; }

        [DisplayName("Nombre Aeropuerto Destino")]
        [Required(ErrorMessage = "El nombre del aeropuerto es requerido")]
        public string nombre_aeropuerto_destino { get; set; }

        [DisplayName("Nombre País Origen")]
        [Required(ErrorMessage = "Campo requerido")]
        public string pais_origen { get; set; }

        [DisplayName("Nombre País Destino")]
        [Required(ErrorMessage = "Campo requerido")]
        public string pais_destino { get; set; }

        [DisplayName("Cantidad de maletas extra")]
        [Required(ErrorMessage = "Campo requerido")]
        public int cant_maletas_extra { get; set; }

        [DisplayName("Número de Asiento")]
        [Required(ErrorMessage = "Campo requerido")]
        public string asiento { get; set; }

        [DisplayName("Precio maleta adicional")]
        [Required(ErrorMessage = "Campo requerido")]
        public int precio_maleta { get; set; }

        [DisplayName("Total Maletas")]
        [Required(ErrorMessage = "Campo requerido")]
        public int total_maletas { get; set; }

        [DisplayName("Total a Pagar")]
        [Required(ErrorMessage = "Campo requerido")]
        public int total { get; set; }

        [DisplayName("Número de Asiento Regreso")]
        [Required(ErrorMessage = "Campo requerido")]
        public string asientoRegreso { get; set; }

        [DisplayName("Información de Salida")]
        public string fullOrigen
        {
            get
            {
                return pais_origen + " - " + origen_iata + " - " + nombre_aeropuerto_origen;
            }

        }

        [DisplayName("Información de Destino")]
        public string fullDestino
        {
            get
            {
                return pais_destino + " - " + destino_iata + " - " + nombre_aeropuerto_destino;
            }

        }

        [DisplayName("Nombre Completo")]
        public string nombreCompleto
        {
            get
            { 
            return nombre + " " + apellido1 + " " + apellido2;
            }
        }
    }
}
