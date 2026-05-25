using DrakionTech.Crm.Business.Common;
using DrakionTech.Crm.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace DrakionTech.Crm.Business.DTOs.Empleado
{
    public class ActualizarEmpleadoDto
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = MensajesError.NombreObligatorio)]
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = MensajesError.ApellidoObligatorio)]
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$")]
        public string Apellido { get; set; } = null!;

        [Required(ErrorMessage = MensajesError.EmailObligatorio)]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Cargo { get; set; } = null!;

        [Required]
        public string Rol { get; set; } = null!;
        [Required(ErrorMessage = MensajesError.TipoDocumentoObligatorio)]
        public TipoDocumento TipoDocumento { get; set; }

        [Required(ErrorMessage = MensajesError.NumeroDocumentoObligatorio)]
        [RegularExpression(@"^\d+$", ErrorMessage = MensajesError.NumeroDocumentoSoloNumeros)]
        [StringLength(20, MinimumLength = 5, ErrorMessage = MensajesError.NumeroDocumentoLongitud)]
        public string NumeroDocumento { get; set; } = null!;

        public decimal? Salario { get; set; }
    }
}