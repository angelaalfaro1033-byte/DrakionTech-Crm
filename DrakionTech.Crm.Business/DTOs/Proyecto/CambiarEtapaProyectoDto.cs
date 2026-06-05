using DrakionTech.Crm.Data.Entities.Enums;

public class CambiarEtapaProyectoDto
{
    public int ProyectoId { get; set; }
    public EtapaFlujoProyecto NuevaEtapa { get; set; }
    public decimal? PorcentajeIva { get; set; }
    public decimal? ValorCalculado { get; set; }
    public string? Observaciones { get; set; }
}