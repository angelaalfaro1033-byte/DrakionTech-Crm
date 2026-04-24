using System.ComponentModel.DataAnnotations;

namespace DrakionTech.Crm.Business.DTOs.Empleado
{
    public class ActualizarEmpleadoDto
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$")]
        public string Apellido { get; set; } = null!;

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Cargo { get; set; } = null!;

        [Required]
        public string Rol { get; set; } = null!;
    }
}