using System.ComponentModel.DataAnnotations;

namespace AirTiquiciaTry.Models
{
    public class PasajerosModel
    {
        public int id { get; set; }

        public string nombre { get; set; }

        public string apellido1 { get; set; }   

        public string apellido2 { get; set; }

        public DateTime fecha_nac { get; set; }

        [RegularExpression(@"^[\w-_]+(\.[\w!#$%'*+\/=?\^`{|}]+)*@((([\-\w]+\.)+[a-zA-Z]{2,20})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessage = "Formato de correo invalido")]
        public string correo { get; set; }

        public string telefono { get; set; }

    }
}
