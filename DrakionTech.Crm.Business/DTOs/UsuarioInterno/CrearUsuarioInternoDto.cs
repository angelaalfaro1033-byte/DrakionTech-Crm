using System.ComponentModel.DataAnnotations;

namespace DrakionTech.Crm.Business.DTOs.UsuarioInterno
{
    public class CrearUsuarioInternoDto
    {
        [Required]
        [MaxLength(150)]
        public string Nombre { get; set; } = string.Empty;

        [MaxLength(150)]
        public string? Apellido { get; set; }

        [MaxLength(200)]
        [EmailAddress]
        public string? Email { get; set; }

        [MaxLength(50)]
        public string? Telefono { get; set; }
    }
}