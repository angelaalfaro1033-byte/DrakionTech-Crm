using DrakionTech.Crm.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace DrakionTech.Crm.Business.DTOs.Marketing;

public class CrearMetricaPublicacionDto
{
    [Required]
    public int PublicacionMarketingId { get; set; }

    [Required]
    public RedSocial RedSocial { get; set; }

    public DateTime FechaRegistro { get; set; } = DateTime.Today;

    public int Visualizaciones { get; set; }

    public int Reacciones { get; set; }

    public int Alcance { get; set; }

    public bool ContactoAreaComercial { get; set; }

    public string? Observaciones { get; set; }
}