namespace DrakionTech.Crm.Business.DTOs.Marketing;
using DrakionTech.Crm.Data.Entities.Enums;

public class MetricaPublicacionDto
{
    public int Id { get; set; }
    public int PublicacionMarketingId { get; set; }

    public string PublicacionNombre { get; set; } = string.Empty;

    public RedSocial RedSocial { get; set; }

    public string RedSocialNombre => RedSocial switch
    {
        RedSocial.WhatsAppBusiness => "WhatsApp Business",
        RedSocial.Instagram => "Instagram",
        RedSocial.LinkedIn => "LinkedIn",
        RedSocial.PaginaWeb => "Página Web",
        RedSocial.EventoFeria => "Evento / Feria",
        _ => RedSocial.ToString()
    };

    public DateTime FechaRegistro { get; set; }

    public int Visualizaciones { get; set; }

    public int Reacciones { get; set; }

    public int Alcance { get; set; }

    public bool ContactoAreaComercial { get; set; }

    public string? Observaciones { get; set; }
}