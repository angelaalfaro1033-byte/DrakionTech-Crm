using DrakionTech.Crm.Business.Common;
using DrakionTech.Crm.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace DrakionTech.Crm.Business.DTOs.Empleado
{
    public class CrearEmpleadoDto
    {
        [Required(ErrorMessage = MensajesError.TipoDocumentoObligatorio)]
        public TipoDocumento TipoDocumento { get; set; }

        [Required(ErrorMessage = MensajesError.NumeroDocumentoObligatorio)]
        [RegularExpression(@"^\d+$", ErrorMessage = MensajesError.NumeroDocumentoSoloNumeros)]
        [StringLength(20, MinimumLength = 5, ErrorMessage = MensajesError.NumeroDocumentoLongitud)]
        public string NumeroDocumento { get; set; } = null!;

        [Required(ErrorMessage = MensajesError.NombreObligatorio)]
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$", ErrorMessage = MensajesError.NombreSoloLetras)]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = MensajesError.ApellidoObligatorio)]
        [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$", ErrorMessage = MensajesError.ApellidoSoloLetras)]
        public string Apellido { get; set; } = null!;

        [Required(ErrorMessage = MensajesError.EmailObligatorio)]
        [EmailAddress(ErrorMessage = MensajesError.EmailInvalido)]
        public string Email { get; set; } = null!;

        [Range(1, int.MaxValue, ErrorMessage = MensajesError.RolSeleccionar)]
        public int RolUsuarioId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = MensajesError.EspecialidadSeleccionar)]
        public int EspecialidadId { get; set; }

        public decimal? Salario { get; set; }
    }
}