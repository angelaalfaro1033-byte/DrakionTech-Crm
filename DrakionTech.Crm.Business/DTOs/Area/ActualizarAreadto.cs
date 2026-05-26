using System.ComponentModel.DataAnnotations;
using DrakionTech.Crm.Business.Common;

namespace DrakionTech.Crm.Business.DTOs.Area;

public class ActualizarAreaDto
{
    [Required(ErrorMessage = MensajesError.AreaNombreObligatorio)]
    [StringLength(100, MinimumLength = 2, ErrorMessage = MensajesError.AreaNombreLongitud)]
    public string Nombre { get; set; } = string.Empty;

    [StringLength(300, ErrorMessage = MensajesError.AreaDescripcionLongitud)]
    public string? Descripcion { get; set; }

    public bool Activa { get; set; }
    public int? ResponsableId { get; set; }
}