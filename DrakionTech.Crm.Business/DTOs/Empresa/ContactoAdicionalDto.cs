using System.ComponentModel.DataAnnotations;

namespace DrakionTech.Crm.Business.DTOs.Empresa
{
    public class ContactoAdicionalDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El apellido es obligatorio")]
        public string Apellido { get; set; } = null!;

        public string? Cargo { get; set; }

        [EmailAddress(ErrorMessage = "Correo inválido")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "Ingrese un teléfono válido.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Solo se permiten números.")]
        [StringLength(15, MinimumLength = 7,
            ErrorMessage = "El teléfono debe tener entre 7 y 15 dígitos.")]
        public string? Telefono { get; set; }

        public int? RolContactoId { get; set; }
    }
}