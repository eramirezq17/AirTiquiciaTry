using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AirTiquiciaTry.Models
{
    public class UsuariosModel
    {
        [Key]

        [DisplayName("Nombre de Usuario")]
        public string username { get; set; }

        [DisplayName("Contraseña")]
        [Required]
        public string password { get; set; }

        [DisplayName("Nombre")]
        [Required]
        public string nombre { get; set; }

        [DisplayName("Primer Apellido")]
        [Required]
        public string apellido1 { get; set; }

        [DisplayName("Segundo Apellido")]
        [Required]
        public string apellido2 { get; set; }

        [DisplayName("Correo electrónico (email)")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}]", ErrorMessage = "Formato Invalido, favor ingresar un correo electrónico")]
        [Required]

        public string email { get; set; }


        public string rol { get; set; }
    }
}
