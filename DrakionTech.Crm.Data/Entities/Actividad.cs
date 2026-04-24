namespace DrakionTech.Crm.Data.Entities
{
    public class Actividad
    {
        public int Id { get; set; }

        public int TipoActividadId { get; set; }
        public TipoActividad TipoActividad { get; set; } = null!;

        public int EstadoActividadId { get; set; }
        public EstadoActividad EstadoActividad { get; set; } = null!;

        public int UsuarioInternoId { get; set; }
        public UsuarioInterno UsuarioInterno { get; set; } = null!;

        public DateTime Inicio { get; set; }
        public DateTime? Fin { get; set; }

        public string? Resultado { get; set; }
        public string? Notas { get; set; }

        public string? ExternalCalendarEventId { get; set; }

        public int? EmpresaId { get; set; }
        public Empresa? Empresa { get; set; }

        public int? ContactoId { get; set; }
        public Contacto? Contacto { get; set; }

        public int? OportunidadId { get; set; }
        public Oportunidad? Oportunidad { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        public ICollection<ActividadUsuario> UsuariosAsignados { get; set; }
            = new List<ActividadUsuario>();
    }
}