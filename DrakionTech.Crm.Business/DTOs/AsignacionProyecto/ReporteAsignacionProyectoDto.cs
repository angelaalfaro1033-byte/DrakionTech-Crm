namespace DrakionTech.Crm.Business.DTOs.AsignacionProyecto;

public class ReporteAsignacionProyectoDto
{
    public int EmpleadoId { get; set; }
    public string EmpleadoNombre { get; set; } = string.Empty;
    public string? Rol { get; set; }
    public int CantidadProyectos { get; set; }
    public string Proyectos { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
}
