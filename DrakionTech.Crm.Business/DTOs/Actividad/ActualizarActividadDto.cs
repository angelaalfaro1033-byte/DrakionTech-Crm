using System.ComponentModel.DataAnnotations;

namespace DrakionTech.Crm.Business.DTOs.Actividad
{
    public class ActualizarActividadDto
    {
        public int? ContactoId { get; set; }
        public int? OportunidadId { get; set; }

        [Required]
        public int UsuarioInternoId { get; set; }

        [Required]
        public int TipoActividadId { get; set; }

        [Required]
        public int EstadoActividadId { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [MaxLength(1000)]
        public string? Resultado { get; set; }

        [MaxLength(2000)]
        public string? Notas { get; set; }
    }
}