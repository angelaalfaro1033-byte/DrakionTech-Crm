using DrakionTech.Crm.Business.Common;
using System.ComponentModel.DataAnnotations;

namespace DrakionTech.Crm.Business.DTOs.Usuario;

public class CrearUsuarioDto
{
    [Required(ErrorMessage = MensajesError.NombreObligatorio)]
    [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$", ErrorMessage = MensajesError.NombreSoloLetras)]
    public string Nombre { get; set; } = null!;

    [Required(ErrorMessage = MensajesError.ApellidoObligatorio)]
    [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$", ErrorMessage = MensajesError.ApellidoSoloLetras)]
    public string Apellido { get; set; } = null!;

    [Required(ErrorMessage = MensajesError.EmailObligatorio)]
    [EmailAddress(ErrorMessage = MensajesError.EmailInvalido)]
    public string Email { get; set; } = null!;

    [Phone(ErrorMessage = MensajesError.TelefonoInvalido)]
    public string? Telefono { get; set; }

    [Required(ErrorMessage = MensajesError.RolObligatorio)]
    [Range(1, int.MaxValue, ErrorMessage = MensajesError.RolSeleccionar)]
    public int RolId { get; set; }
}