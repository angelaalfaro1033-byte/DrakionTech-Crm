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

    public int? SupervisorInternoId { get; set; }
    public int? SupervisorExternoId { get; set; }

    [Required(ErrorMessage = "Selecciona una oportunidad.")]
    public int? OportunidadId { get; set; }

    public decimal? PresupuestoTotal { get; set; }
    public string? EquipoTrabajo { get; set; }
    public string? Soporte { get; set; }

    public string? Observaciones { get; set; }
    public string? DocumentosUrl { get; set; }

    // Fases iniciales (se serializan a JSON)
    public List<FaseProyectoDto> Fases { get; set; } = GenerarFasesDefault();

    public static List<FaseProyectoDto> GenerarFasesDefault() => new()
    {
        new() { EtapaFlujo = EtapaFlujoProyecto.FirmaContrato, Nombre = "Firma de contrato" },
        new() { EtapaFlujo = EtapaFlujoProyecto.PagoProyecto, Nombre = "Pago del proyecto" },
        new() { EtapaFlujo = EtapaFlujoProyecto.ConformacionEquipo, Nombre = "Conformación del equipo" },
        new() { EtapaFlujo = EtapaFlujoProyecto.ReunionInicial, Nombre = "Reunión inicial" },
        new() { EtapaFlujo = EtapaFlujoProyecto.InformacionGeneral, Nombre = "Información general" },
        new() { EtapaFlujo = EtapaFlujoProyecto.EjecucionProyecto, Nombre = "Ejecución del proyecto" },
        new() { EtapaFlujo = EtapaFlujoProyecto.SeguimientoFases, Nombre = "Seguimiento de fases" },
        new() { EtapaFlujo = EtapaFlujoProyecto.ActasEntregaFase, Nombre = "Actas de entrega de fase" },
        new() { EtapaFlujo = EtapaFlujoProyecto.ReunionCierre, Nombre = "Reunión de cierre" },
        new() { EtapaFlujo = EtapaFlujoProyecto.ActaFinal, Nombre = "Acta final" },
        new() { EtapaFlujo = EtapaFlujoProyecto.Otrosi, Nombre = "Otrosí" },
        new() { EtapaFlujo = EtapaFlujoProyecto.Calificacion, Nombre = "Calificación" },
        new() { EtapaFlujo = EtapaFlujoProyecto.CierreProyecto, Nombre = "Cierre del proyecto" }
    };
}
