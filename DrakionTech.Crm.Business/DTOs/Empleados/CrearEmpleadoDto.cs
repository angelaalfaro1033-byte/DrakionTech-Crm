using DrakionTech.Crm.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace DrakionTech.Crm.Business.DTOs.Empleado
{
    public class CrearEmpleadoDto
    {
        [Required(ErrorMessage = "El tipo de documento es obligatorio")]
        public TipoDocumento TipoDocumento { get; set; }

        [Required(ErrorMessage = "El número de documento es obligatorio")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El número de documento solo puede contener números")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "El número de documento debe tener entre 5 y 20 dígitos")]
        public string NumeroDocumento { get; set; } = null!;

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$", ErrorMessage = "El nombre solo puede contener letras")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$", ErrorMessage = "El apellido solo puede contener letras")]
        public string Apellido { get; set; } = null!;

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "El correo no es válido")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "El rol es obligatorio")]
        public string Rol { get; set; } = null!;
        public int? RolUsuarioId { get; set; }

        [Required(ErrorMessage = "El cargo es obligatorio")]
        public string Cargo { get; set; } = null!;
        public int? EspecialidadId { get; set; }

        public decimal? Salario { get; set; }
    }
}