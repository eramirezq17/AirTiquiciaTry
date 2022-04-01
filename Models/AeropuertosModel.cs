using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AirTiquiciaTry.Models
{
    public class AeropuertosModel
    {
       [DisplayName("Codigo Aeropuerto")]
       [Required]
        
        public string cod_iata { get; set; }

        [DisplayName("Nombre Aeropuerto")]
        [Required]
        public string nombre_aeropuerto { get; set; }

        [DisplayName("Codigo Pais")]
        [Required]
        public  string cod_pais { get; set; }

        [DisplayName("Nombre Pais")]
        [Required]
        public string nombre_pais { get; set; }

    }
}
