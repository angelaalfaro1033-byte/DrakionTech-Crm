using DrakionTech.Crm.Business.Common;
using System.ComponentModel.DataAnnotations;

namespace DrakionTech.Crm.Business.DTOs.Oportunidad
{
    public class CrearOportunidadDto
    {
        [Required(ErrorMessage = MensajesError.NombreProyectoObligatorio)]
        public string NombreProyecto { get; set; } = string.Empty;

        [Required]
        public int EmpresaId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = MensajesError.ValorEstimadoMayorACero)]
        public decimal ValorEstimado { get; set; }
        public DateTime? FechaEstimadaCierre { get; set; }
        public string? Descripcion { get; set; }
    }
}