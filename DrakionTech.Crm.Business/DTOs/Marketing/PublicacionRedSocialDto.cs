using DrakionTech.Crm.Data.Entities.Enums;

namespace DrakionTech.Crm.Business.DTOs.Marketing;

public class PublicacionRedSocialDto
{
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

    public bool TienePauta { get; set; }

    public decimal? CostoPauta { get; set; }

    public int? DiasPauta { get; set; }
}