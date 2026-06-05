using System.ComponentModel.DataAnnotations;

namespace DrakionTech.Crm.Business.DTOs.Empresa
{
    public class ContactoPrincipalDto
    {
        [Required(ErrorMessage = "El nombre del contacto es obligatorio")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El apellido del contacto es obligatorio")]
        public string Apellido { get; set; } = null!;

        public string? Cargo { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public string? Telefono { get; set; }

        public int? RolContactoId { get; set; }
    }
}