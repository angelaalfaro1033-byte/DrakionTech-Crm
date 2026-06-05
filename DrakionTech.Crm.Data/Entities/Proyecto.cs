using DrakionTech.Crm.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrakionTech.Crm.Data.Entities;

public class Proyecto
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
    public int? SupervisorId { get; set; }
    public Usuario? Supervisor { get; set; }
    public string? EquipoTrabajo { get; set; }   // nombres separados por coma o JSON simple
    public string? Soporte { get; set; }

    // Pagos
    public DateTime? FechaPago { get; set; }
    public string? RecordatorioPago { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? MontoPagado { get; set; }

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

    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    public DateTime? FechaUltimaModificacion { get; set; }
}