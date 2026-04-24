namespace DrakionTech.Crm.Business.DTOs.Actividad
{
    public class ActividadDto
    {
        public int Id { get; set; }

        public int EmpresaId { get; set; }
        public string EmpresaNombre { get; set; } = null!;

        public int? ContactoId { get; set; }
        public string? ContactoNombre { get; set; }

        public int? OportunidadId { get; set; }
        public string? OportunidadNombre { get; set; }

        public int UsuarioInternoId { get; set; }
        public string UsuarioInternoNombre { get; set; } = null!;

        public int TipoActividadId { get; set; }
        public string TipoActividadNombre { get; set; } = null!;

        public int EstadoActividadId { get; set; }
        public string EstadoActividadNombre { get; set; } = null!;

        public DateTime Fecha { get; set; }

        public string? Resultado { get; set; }
        public string? Notas { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}