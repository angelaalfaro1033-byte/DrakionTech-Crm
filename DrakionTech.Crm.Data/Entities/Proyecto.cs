using DrakionTech.Crm.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrakionTech.Crm.Data.Entities;

public class Proyecto : DrakionTech.Crm.Data.Entities.Base.AuditableEntity
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public EstadoProyecto Estado { get; set; } = EstadoProyecto.Activo;
    public DateTime FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }

    // Presupuesto
    [Column(TypeName = "decimal(18,2)")]
    public decimal? PresupuestoTotal { get; set; }

    // Flujo operativo
    public EtapaFlujoProyecto EtapaFlujo { get; set; } = EtapaFlujoProyecto.FirmaContrato;

    // Equipo
    public int? SupervisorInternoId { get; set; }
    public Usuario? SupervisorInterno { get; set; }
    public int? SupervisorExternoId { get; set; }
    public Contacto? SupervisorExterno { get; set; }
    public string? EquipoTrabajo { get; set; }   // nombres separados por coma o JSON simple
    public string? Soporte { get; set; }

    // Observaciones y documentos
    public string? Observaciones { get; set; }
    public string? DocumentosUrl { get; set; }

    // Fases (JSON serializado — configurable por proyecto)
    public string? FasesJson { get; set; }

    // Relaciones
    public int AreaId { get; set; }
    public Area Area { get; set; } = null!;

    public int ResponsableId { get; set; }
    public Usuario Responsable { get; set; } = null!;

    public int? OportunidadId { get; set; }
    public Oportunidad? Oportunidad { get; set; }
    public ICollection<PagoProyecto> Pagos { get; set; } = new List<PagoProyecto>();
    public ICollection<EmpleadoProyectoAsignacion> AsignacionesEmpleado { get; set; } = new List<EmpleadoProyectoAsignacion>();

    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    public DateTime? FechaUltimaModificacion { get; set; }
}
