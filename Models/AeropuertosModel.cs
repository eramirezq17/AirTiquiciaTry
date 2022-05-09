using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AirTiquiciaTry.Models
{
    public class AeropuertosModel
    {
       [DisplayName("Codigo Aeropuerto")]
       [Key]
        [Required(ErrorMessage = "El codigo de aeropuerto es requerido")]
        [StringLength(maximumLength: 3, MinimumLength = 3, ErrorMessage = "El codigo de aeropuerto debe tener 3 caracteres")]
        [DisplayFormat()]
        public string cod_iata { get; set; }

        [DisplayName("Nombre Aeropuerto")]
        [Required(ErrorMessage = "El nombre del aeropuerto es requerido")]
        public string nombre_aeropuerto { get; set; }

        [DisplayName("Codigo Pais")]
        [Required(ErrorMessage = "El codigo de pais es requerido")]
        [StringLength(maximumLength: 2, MinimumLength = 2, ErrorMessage = "El codigo de pais debe tener 2 caracteres")]

        public string cod_pais { get; set; }

        [DisplayName("Nombre Pais")]
        [Required(ErrorMessage = "El nombre de pais es requerido")]
        public string nombre_pais { get; set; }


        public string fullDesc
        {
            get
            {
                return nombre_pais + " - " + cod_iata + " - " + nombre_aeropuerto;
            }

        }


    }
}
