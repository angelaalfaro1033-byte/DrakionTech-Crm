using DrakionTech.Crm.Data.Entities.Enums;

namespace DrakionTech.Crm.Data.Entities;

public class HistorialEtapaProyecto
{
    public int Id { get; set; }
    public int ProyectoId { get; set; }
    public Proyecto Proyecto { get; set; } = null!;
    public EtapaFlujoProyecto EtapaAnterior { get; set; }
    public EtapaFlujoProyecto EtapaNueva { get; set; }
    public decimal? PorcentajeIva { get; set; }
    public decimal? ValorCalculado { get; set; }
    public string? Observaciones { get; set; }
    public DateTime FechaCambio { get; set; } = DateTime.UtcNow;
}