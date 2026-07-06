using System.ComponentModel.DataAnnotations;

namespace DrakionTech.Crm.Business.DTOs.AsignacionProyecto;

public class CrearAsignacionProyectoDto
{
    public int EmpleadoId { get; set; }
    public int ProyectoId { get; set; }
    public DateTime FechaInicio { get; set; } = DateTime.UtcNow;
    [Range(1, 100, ErrorMessage = "El porcentaje de dedicacion debe estar entre 1 y 100.")]
    public decimal PorcentajeDedicacion { get; set; } = 100m;
    public string? RolEnProyecto { get; set; }
    public string? Observaciones { get; set; }
}
