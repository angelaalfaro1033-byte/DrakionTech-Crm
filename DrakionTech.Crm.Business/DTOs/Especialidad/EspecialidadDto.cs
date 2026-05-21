using DrakionTech.Crm.Business.Common;
using System.ComponentModel.DataAnnotations;

namespace DrakionTech.Crm.Business.DTOs.Especialidad
{
    public class EspecialidadDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = MensajesError.EspecialidadNombreObligatorio)]
        [StringLength(100, MinimumLength = 2, ErrorMessage = MensajesError.EspecialidadNombreLongitud)]
        public string Nombre { get; set; } = null!;

        [StringLength(300, ErrorMessage = MensajesError.EspecialidadDescripcionLongitud)]
        public string? Descripcion { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = MensajesError.EspecialidadRolObligatorio)]
        public int RolUsuarioId { get; set; }

        public string? RolUsuarioNombre { get; set; }
        public bool Activo { get; set; } = true;
    }
}