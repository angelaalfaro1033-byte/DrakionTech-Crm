using System.ComponentModel.DataAnnotations;

namespace DrakionTech.Crm.Business.DTOs.Usuario;

public class CrearUsuarioDto
{
    [Required(ErrorMessage = "El nombre es obligatorio")]
    [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$", ErrorMessage = "El nombre solo puede contener letras")]
    public string Nombre { get; set; } = null!;

    [Required(ErrorMessage = "El apellido es obligatorio")]
    [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$", ErrorMessage = "El apellido solo puede contener letras")]
    public string Apellido { get; set; } = null!;

    [Required(ErrorMessage = "El correo es obligatorio")]
    [EmailAddress(ErrorMessage = "El correo no es válido")]
    public string Email { get; set; } = null!;

    [Phone(ErrorMessage = "El teléfono no es válido")]
    public string? Telefono { get; set; }

    [Required(ErrorMessage = "El rol es obligatorio")]
    [Range(1, int.MaxValue, ErrorMessage = "Selecciona un rol")]
    public int RolId { get; set; }
}