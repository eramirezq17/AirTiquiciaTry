using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AirTiquiciaTry.Models
{
    public class AvionesModel
    {
        [DisplayName("Id Avion")]
        [Required(ErrorMessage = "El Id del avión es requerido")]
        public int id_avion { get; set; }

        [DisplayName("Marca")]
        [Required(ErrorMessage = "La marca del avión es requerida")]
        public string marca { get; set; }

        [DisplayName("Modelo")]
        [Required(ErrorMessage = "El modelo del avión es requerido")]
        public string modelo { get; set; }

        [DisplayName("Id Tipo de Avión")]
        [Range(1,3, ErrorMessage = "El Id de tipo de avión puede ser 1, 2 o 3")]

        public int id_tipo_avion { get; set; }
        
        [DisplayName("Tipo de Avión")]
        public string nombre_tipo_avion { get; set; }

    }
}
