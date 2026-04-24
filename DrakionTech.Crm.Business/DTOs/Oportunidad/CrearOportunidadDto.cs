using System.ComponentModel.DataAnnotations;

namespace DrakionTech.Crm.Business.DTOs.Oportunidad
{
    public class CrearOportunidadDto
    {
        [Required(ErrorMessage = "El nombre del proyecto es obligatorio")]
        public string NombreProyecto { get; set; } = string.Empty;

        [Required]
        public int EmpresaId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El valor estimado debe ser mayor a cero")]
        public decimal ValorEstimado { get; set; }
        public DateTime? FechaEstimadaCierre { get; set; }
        public string? Descripcion { get; set; }
    }
}