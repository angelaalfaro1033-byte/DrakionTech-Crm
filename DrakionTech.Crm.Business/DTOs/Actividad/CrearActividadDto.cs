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
        public int UsuarioInternoId { get; set; }

        [Required(ErrorMessage = "El tipo de actividad es obligatorio")]
        public int? TipoActividadId { get; set; }

        [Required(ErrorMessage = "El estado de la actividad es obligatorio")]
        public int EstadoActividadId { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime Fecha { get; set; }

        [MaxLength(1000)]
        public string? Resultado { get; set; }

        [MaxLength(2000)]
        public string? Notas { get; set; }
    }
}