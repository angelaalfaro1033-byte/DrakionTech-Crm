namespace DrakionTech.Crm.Business.DTOs.Marketing;

public class CrearPublicacionMarketingDto : PublicacionMarketingBaseDto
{
    public CrearPublicacionMarketingDto()
    {
        FechaPublicacionProgramada = DateTime.Today;
    }
}