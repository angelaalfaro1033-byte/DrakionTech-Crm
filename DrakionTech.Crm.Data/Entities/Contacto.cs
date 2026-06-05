using DrakionTech.Crm.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace DrakionTech.Crm.Data.Entities
{
    public class Contacto
    {
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Nombre { get; set; } = null!;

        [Required, MaxLength(150)]
        public string Apellido { get; set; } = null!;

        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? Cargo { get; set; }  // ← agregar

        public int RolContactoId { get; set; }
        public RolContacto RolContacto { get; set; } = null!;

        public bool EsPrincipal { get; set; }  // ← agregar

        public DateTime? FechaVinculacion { get; set; }
        public DateTime? FechaEspecial { get; set; }

        public int EmpresaId { get; set; }
        public Empresa? Empresa { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    }
}