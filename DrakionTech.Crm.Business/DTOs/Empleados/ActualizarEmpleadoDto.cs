using DrakionTech.Crm.Data.Entities.Enums;
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
        [Required(ErrorMessage = "El tipo de documento es obligatorio")]
        public TipoDocumento TipoDocumento { get; set; }

        [Required(ErrorMessage = "El número de documento es obligatorio")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El número de documento solo puede contener números")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "El número de documento debe tener entre 5 y 20 dígitos")]
        public string NumeroDocumento { get; set; } = null!;

        public decimal? Salario { get; set; }
    }
}