using DrakionTech.Crm.Data.Entities.Base;
using DrakionTech.Crm.Data.Entities.Enums;

namespace DrakionTech.Crm.Data.Entities;

public class MetricaPublicacion : BaseEntity
{
    public int PublicacionMarketingId { get; set; }

    public PublicacionMarketing PublicacionMarketing { get; set; } = null!;

    public RedSocial RedSocial { get; set; }

    public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;

    public int Visualizaciones { get; set; }

    public int Reacciones { get; set; }

    public int Alcance { get; set; }

    public bool ContactoAreaComercial { get; set; }

    public string? Observaciones { get; set; }
}