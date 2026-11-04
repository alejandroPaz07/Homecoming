
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homecoming.Models
{
    public class Estudiante
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ\s]+$",
            ErrorMessage = "El nombre solo debe contener letras.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ\s]+$",
            ErrorMessage = "El apellido solo debe contener letras.")]
        public string Apellido { get; set; } = string.Empty;

        [Required(ErrorMessage = "La cédula es obligatoria.")]
        [RegularExpression(@"^\d{10}$",
            ErrorMessage = "La cédula debe contener exactamente 10 números.")]
        public string Cedula { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "Ingresa un correo electrónico válido.")]
        public string Correo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debes seleccionar un nivel.")]
        [RegularExpression("^(Primer nivel|Segundo nivel|Tercer nivel|Cuarto nivel)$",
     ErrorMessage = "Selecciona un nivel válido.")]
        public string Nivel { get; set; } = string.Empty;

        [Required]
        public string Modalidad { get; set; } = string.Empty;

        public string Jornada { get; set; } = string.Empty;

        public DateTime FechaRegistro { get; set; }
        public bool BotellasEntregadas { get; set; } = false;
        public string? CodigoQR { get; set; }

        public bool EntradaUtilizada { get; set; } = false;
        public int CantidadBotellas { get; set; } = 0;
    }
}
