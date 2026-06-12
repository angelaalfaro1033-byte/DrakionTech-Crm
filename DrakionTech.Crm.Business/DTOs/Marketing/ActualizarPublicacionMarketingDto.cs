using DrakionTech.Crm.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace DrakionTech.Crm.Business.DTOs.Marketing;

public class ActualizarPublicacionMarketingDto
{
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Nombre { get; set; } = string.Empty;

    public string? DescripcionCampania { get; set; }

    [Required]
    public string CopyUtilizado { get; set; } = string.Empty;

    public string? Observaciones { get; set; }

    [Required]
    public int ResponsableId { get; set; }

    [Required]
    public DateTime FechaPublicacionProgramada { get; set; }

    public DateTime? FechaPublicacionReal { get; set; }

    public bool EnvioAutomatico { get; set; }

    public EstadoPublicacionMarketing Estado { get; set; }

    public List<RedSocialPublicacionDto> RedesSociales { get; set; } = new();
    public List<ArchivoPublicacionDto> Archivos { get; set; } = new();
}