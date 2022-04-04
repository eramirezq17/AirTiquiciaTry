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
        [Required(ErrorMessage = "La marca del avion es requerida")]
        public string marca { get; set; }

        [DisplayName("Modelo")]
        [Required(ErrorMessage = "El modelo del avion es requerido")]
        public string modelo { get; set; }

        [DisplayName("Id Tipo de Avion")]
        [Range(1,3, ErrorMessage = "El Id de tipo de avion puede ser 1, 2 o 3")]

        public int id_tipo_avion { get; set; }
        
        [DisplayName("Tipo de Avion")]
        public string nombre_tipo_avion { get; set; }

    }
}
