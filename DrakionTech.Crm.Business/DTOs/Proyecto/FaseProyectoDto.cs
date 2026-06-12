using DrakionTech.Crm.Data.Entities.Enums;

namespace DrakionTech.Crm.Business.DTOs.Proyecto;

public class FaseProyectoDto
{
    public EtapaFlujoProyecto? EtapaFlujo { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public decimal PorcentajeFase { get; set; }       // % del presupuesto total
    public decimal Iva { get; set; }                   // % de IVA
    public decimal ValorCalculado { get; set; }        // calculado automático
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
    public int PorcentajeAvance { get; set; }          // 0-100
    public string? Observaciones { get; set; }
    public string? ActaEntrega { get; set; }
    public bool Completada { get; set; }
}
