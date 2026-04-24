using System.ComponentModel.DataAnnotations;

namespace DrakionTech.Crm.Business.DTOs.Empleado
{
    public class CrearEmpleadoDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$",
            ErrorMessage = "El nombre solo puede contener letras")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$",
            ErrorMessage = "El apellido solo puede contener letras")]
        public string Apellido { get; set; } = null!;

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "El correo no es válido")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "El cargo es obligatorio")]
        public string Cargo { get; set; } = null!;

        [Required(ErrorMessage = "El rol es obligatorio")]
        public string Rol { get; set; } = null!;
    }
}