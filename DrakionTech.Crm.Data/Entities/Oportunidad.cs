using DrakionTech.Crm.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrakionTech.Crm.Data.Entities
{
    public class Oportunidad
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string NombreProyecto { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorEstimado { get; set; }

        public EtapaOportunidad Etapa { get; set; }

        public DateTime? FechaEstimadaCierre { get; set; }

        public string? Descripcion { get; set; }

        // FK
        public int EmpresaId { get; set; }

        public int? ContactoPrincipalId { get; set; }

        // Navegación
        public Empresa? Empresa { get; set; }
        public Contacto? ContactoPrincipal { get; set; }

        public ICollection<Propuesta> Propuestas { get; set; } = new List<Propuesta>();
        public ICollection<HistorialCambioOportunidad> HistorialCambios { get; set; } = new List<HistorialCambioOportunidad>();

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    }
}