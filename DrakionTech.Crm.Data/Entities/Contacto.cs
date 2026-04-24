using DrakionTech.Crm.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace DrakionTech.Crm.Data.Entities
{
    public class Contacto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nombre { get; set; } = null!;

        [Required]
        [MaxLength(150)]
        public string Apellido { get; set; } = null!;

        public string? Email { get; set; }

        public string? Telefono { get; set; }

        public int RolContactoId { get; set; }
        public RolContacto RolContacto { get; set; } = null!;

        /// <summary>
        /// Fecha en la que el contacto se vinculó con la empresa
        /// </summary>
        public DateTime? FechaVinculacion { get; set; }

        /// <summary>
        /// Fechas especiales del contacto (cumpleaños, etc.)
        /// </summary>
        public DateTime? FechaEspecial { get; set; }

        // FK
        public int EmpresaId { get; set; }

        // Navegación
        public Empresa? Empresa { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    }
}