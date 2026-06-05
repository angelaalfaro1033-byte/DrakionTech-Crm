using DrakionTech.Crm.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace DrakionTech.Crm.Business.DTOs.Proyecto;

public class CrearProyectoDto
{
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [MaxLength(150)]
    public string Nombre { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Descripcion { get; set; }

    public EstadoProyecto Estado { get; set; } = EstadoProyecto.Activo;
    public EtapaFlujoProyecto EtapaFlujo { get; set; } = EtapaFlujoProyecto.FirmaContrato;

    [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
    public DateTime FechaInicio { get; set; } = DateTime.Today;
    public DateTime? FechaFin { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Selecciona un área.")]
    public int AreaId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Selecciona un responsable.")]
    public int ResponsableId { get; set; }

    public int? SupervisorId { get; set; }
    public int? OportunidadId { get; set; }

    public decimal? PresupuestoTotal { get; set; }
    public string? EquipoTrabajo { get; set; }
    public string? Soporte { get; set; }

    public DateTime? FechaPago { get; set; }
    public string? RecordatorioPago { get; set; }
    public decimal? MontoPagado { get; set; }

    public string? Observaciones { get; set; }
    public string? DocumentosUrl { get; set; }

    // Fases iniciales (se serializan a JSON)
    public List<FaseProyectoDto> Fases { get; set; } = GenerarFasesDefault();

    public static List<FaseProyectoDto> GenerarFasesDefault() => new()
    {
        new() { Nombre = "Firma de contrato" },
        new() { Nombre = "Pago del proyecto" },
        new() { Nombre = "Conformación del equipo" },
        new() { Nombre = "Reunión inicial" },
        new() { Nombre = "Información general" },
        new() { Nombre = "Ejecución del proyecto" },
        new() { Nombre = "Seguimiento de fases" },
        new() { Nombre = "Actas de entrega de fase" },
        new() { Nombre = "Reunión de cierre" },
        new() { Nombre = "Acta final" },
        new() { Nombre = "Otrosí" },
        new() { Nombre = "Calificación" },
        new() { Nombre = "Cierre del proyecto" }
    };
}