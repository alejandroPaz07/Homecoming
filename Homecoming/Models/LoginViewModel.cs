
using System.ComponentModel.DataAnnotations;

namespace Homecoming.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Ingresa tu usuario.")]
        public string Usuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ingresa tu contraseña.")]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; } = string.Empty;
    }
}
