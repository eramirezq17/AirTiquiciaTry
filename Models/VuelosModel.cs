using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AirTiquiciaTry.Models
{
    public class VuelosModel
    {
     [Key]
        [Required]
        [DisplayName("ID Vuelo")]
        public string id_vuelo { get; set; }

        [Required]
        [DisplayName("Fecha y Hora de Salida")]
        public DateTime fecha_hora { get; set; }

        [Required]
        [DisplayName("Es Directo?")]
        public string es_directo { get; set; }

        [Required]
        [DisplayName("ID del Avión")]
        public int id_avion { get; set; }

        [Required(ErrorMessage = "Debe elegir el aeropuerto de salida")]
        [DisplayName("Código IATA del Aeropuerto Origen")]
        public string origen_iata { get; set; }

        [Required]
        [DisplayName("Nombre del Aeropuerto Origen")]
        public string origen_iata_nombre { get; set; }

        [Required]
        [DisplayName("País del Aeropuerto Origen")]
        public string origen_pais { get; set; }

        [Required(ErrorMessage = "Debe elegir el aeropuerto de Destino")]
        [DisplayName("Código IATA del Aeropuerto Destino")]
        public string destino_iata { get; set; }

        [Required]
        [DisplayName("Nombre del Aeropuerto Destino")]
        public string destino_iata_nombre { get; set; }

        [Required]
        [DisplayName("País del Aeropuerto Destino")]
        public string destino_pais { get; set; }

        [Required]
        [DisplayName("Duración del vuelo")]
        public string duracion { get; set; }

        [Required]
        [DisplayName("ID del capitan")]
        public int id_capitan { get; set; }

        [Required]
        [DisplayName("Nombre del capital")]
        public string nombre_capitan { get; set; }

        [Required]
        [DisplayName("Apellido del capital")]
        public string apellido_capitan { get; set; }

        [Required]
        [DisplayName("ID del copiloto")]
        public int id_copiloto { get; set; }

        [Required]
        [DisplayName("Nombre del copiloto")]

        public string nombre_copiloto { get; set; }

        [Required]
        [DisplayName("Apellido del copiloto")]

        public string apellido_copiloto { get; set; }


        [Required]
        [DisplayName("ID del tripulante de cabina")]
        public int id_tripulante_cabina { get; set; }

        [Required]
        [DisplayName("Nombre del tripulante de cabina")]
        public string nombre_tripulante_cabina { get; set; }

        [Required]
        [DisplayName("Apellido del tripulante de cabina")]
        public string apellido_tripulante_cabina { get; set; }

        [Required]
        [DisplayName("Precio en cabina económica")]
        public int precio_economica { get; set; }

        [Required]
        [DisplayName("Precio en primera clase")]
        public int precio_primera { get; set; }

        [Required]
        [DisplayName("Precio del equipaje extra por kilo (en US dólares)")]
        public int precio_equipaje_kilo { get; set; }


        [Required(ErrorMessage = "Campo requerido")]
        [DisplayName("Fecha de Salida")]
        public DateTime fechaSalida { get; set; }


        [Required]
        [DisplayName("Fecha de Regreso")]
        public DateTime fechaRegreso    { get; set; }

        public string tipo_vuelo { get; set; }
    }
}
