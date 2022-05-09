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
        [RegularExpression(@"^[\w-_]+(\.[\w!#$%'*+\/=?\^`{|}]+)*@((([\-\w]+\.)+[a-zA-Z]{2,20})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessage = "Formato de correo invalido")]
        [Required]

        public string email { get; set; }


        public string rol { get; set; }
    }
}
