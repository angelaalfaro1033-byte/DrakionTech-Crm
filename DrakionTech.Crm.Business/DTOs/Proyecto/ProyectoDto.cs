using DrakionTech.Crm.Data.Entities.Enums;

namespace DrakionTech.Crm.Business.DTOs.Proyecto;

public class ProyectoDto : DrakionTech.Crm.Business.DTOs.IHasAuditInfo
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public EstadoProyecto Estado { get; set; }
    public EtapaFlujoProyecto EtapaFlujo { get; set; }

    public string EstadoTexto => Estado switch
    {
        EstadoProyecto.Activo => "Activo",
        EstadoProyecto.Inactivo => "Inactivo",
        _ => Estado.ToString()
    };
    public string EtapaTexto => EtapaFlujo switch
    {
        EtapaFlujoProyecto.FirmaContrato => "Firma de contrato",
        EtapaFlujoProyecto.PagoProyecto => "Pago del proyecto",
        EtapaFlujoProyecto.ConformacionEquipo => "Conformación del equipo",
        EtapaFlujoProyecto.ReunionInicial => "Reunión inicial",
        EtapaFlujoProyecto.InformacionGeneral => "Información general",
        EtapaFlujoProyecto.EjecucionProyecto => "Ejecución del proyecto",
        EtapaFlujoProyecto.SeguimientoFases => "Seguimiento de fases",
        EtapaFlujoProyecto.ActasEntregaFase => "Actas de entrega de fase",
        EtapaFlujoProyecto.ReunionCierre => "Reunión de cierre",
        EtapaFlujoProyecto.ActaFinal => "Acta final",
        EtapaFlujoProyecto.Otrosi => "Otrosí",
        EtapaFlujoProyecto.Calificacion => "Calificación",
        EtapaFlujoProyecto.CierreProyecto => "Cierre del proyecto",
        _ => EtapaFlujo.ToString()
    };

    public DateTime FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
    public decimal? PresupuestoTotal { get; set; }

    public int AreaId { get; set; }
    public string AreaNombre { get; set; } = string.Empty;
    public int ResponsableId { get; set; }
    public string ResponsableNombre { get; set; } = string.Empty;
    public int? SupervisorInternoId { get; set; }
    public string? SupervisorInternoNombre { get; set; }
    public int? SupervisorExternoId { get; set; }
    public string? SupervisorExternoNombre { get; set; }

    public int? OportunidadId { get; set; }
    public string? OportunidadNombre { get; set; }
    public int? EmpresaId { get; set; }
    public string? EmpresaNombre { get; set; }

    public string? EquipoTrabajo { get; set; }
    public string? Soporte { get; set; }

    public string? Observaciones { get; set; }
    public string? DocumentosUrl { get; set; }

    public List<FaseProyectoDto> Fases { get; set; } = new();
    public List<PagoProyectoDto> Pagos { get; set; } = new();
    public DrakionTech.Crm.Business.DTOs.AuditInfoDto? AuditInfo { get; set; }
}
