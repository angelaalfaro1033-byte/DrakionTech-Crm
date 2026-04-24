using System.ComponentModel.DataAnnotations;

namespace DrakionTech.Crm.Business.DTOs.Contacto
{
    public class CrearContactoDto
    {
        public int EmpresaId { get; set; }

        [Required, MaxLength(150)]
        public string Nombre { get; set; } = null!;

        [Required, MaxLength(150)]
        public string Apellido { get; set; } = null!;

        [EmailAddress]
        public string? Email { get; set; }

        public string? Telefono { get; set; }

        [Required]
        public int RolContactoId { get; set; }
    }
}