using DrakionTech.Crm.Business.Common;
using System.ComponentModel.DataAnnotations;

namespace DrakionTech.Crm.Business.DTOs.Actividad
{
    public class CrearActividadDto
    {
        [Required]
        public int EmpresaId { get; set; }

        public int? ContactoId { get; set; }
        public int? OportunidadId { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = MensajesError.TipoActividadObligatorio)]
        public int? TipoActividadId { get; set; }

        [Required(ErrorMessage = MensajesError.EstadoActividadObligatorio)]
        public int EstadoActividadId { get; set; }

        [Required(ErrorMessage = MensajesError.FechaObligatoria)]
        public DateTime Fecha { get; set; }

        public DateTime? FechaFin { get; set; }

        [MaxLength(1000)]
        public string? Resultado { get; set; }

        [MaxLength(2000)]
        public string? Notas { get; set; }
        public int? ActividadPreviaId { get; set; }

    }
}