using DrakionTech.Crm.Data.Entities.Enums;

namespace DrakionTech.Crm.Business.DTOs.Marketing;

public class RedSocialPublicacionDto
{
    public RedSocial RedSocial { get; set; }

    public bool TienePauta { get; set; }

    public decimal? CostoPauta { get; set; }

    public int? DiasPauta { get; set; }
}