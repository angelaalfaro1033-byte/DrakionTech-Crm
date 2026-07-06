using System.ComponentModel.DataAnnotations;

namespace DrakionTech.Crm.Business.DTOs.AsignacionProyecto;

public class ActualizarAsignacionProyectoDto
{
    public int Id { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
    [Range(1, 100, ErrorMessage = "El porcentaje de dedicacion debe estar entre 1 y 100.")]
    public decimal PorcentajeDedicacion { get; set; } = 100m;
    public string? RolEnProyecto { get; set; }
    public string? Observaciones { get; set; }
}
