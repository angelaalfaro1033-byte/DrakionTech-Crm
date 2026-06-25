using DrakionTech.Crm.Data.Entities.Enums;

namespace DrakionTech.Crm.Business.DTOs.Marketing;

public class ActualizarPublicacionMarketingDto : PublicacionMarketingBaseDto
{
    public int Id { get; set; }
    public DateTime? FechaPublicacionReal { get; set; }
    public EstadoPublicacionMarketing Estado { get; set; }
}