using DrakionTech.Crm.Data.Entities.Enums;

namespace DrakionTech.Crm.Business.DTOs.Marketing;

public class PublicacionMarketingDto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public string? DescripcionCampania { get; set; }

    public string CopyUtilizado { get; set; } = string.Empty;

    public string? ArchivoNombre { get; set; }

    public string? ArchivoUrl { get; set; }

    public string? Observaciones { get; set; }

    public int ResponsableId { get; set; }

    public string ResponsableNombre { get; set; } = string.Empty;

    public DateTime FechaCreacion { get; set; }

    public DateTime FechaPublicacionProgramada { get; set; }

    public DateTime? FechaPublicacionReal { get; set; }

    public bool EnvioAutomatico { get; set; }

    public EstadoPublicacionMarketing Estado { get; set; }

    public string EstadoTexto => Estado switch
    {
        EstadoPublicacionMarketing.Borrador => "Borrador",
        EstadoPublicacionMarketing.Programada => "Programada",
        EstadoPublicacionMarketing.Publicada => "Publicada",
        EstadoPublicacionMarketing.Vencida => "Vencida",
        EstadoPublicacionMarketing.Cancelada => "Cancelada",
        _ => Estado.ToString()
    };

    public List<PublicacionRedSocialDto> RedesSociales { get; set; } = new();
    public List<MetricaPublicacionDto> Metricas { get; set; } = new();
    public List<ArchivoPublicacionDto> Archivos { get; set; } = new();
}