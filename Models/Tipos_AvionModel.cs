using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AirTiquiciaTry.Models
{
    public class Tipos_AvionModel
    {
       [DisplayName("Id Tipo")]
       [Key]
        public int id_tipo { get; set; }

        [DisplayName("Nombre")]
        public string nombre { get; set; }

        public int asientos_primera { get; set; }

        public int asientos_economica { get; set; }

    }
}
