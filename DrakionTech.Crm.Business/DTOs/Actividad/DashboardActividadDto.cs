public class DashboardActividadDto
{
    public int TotalPendientes { get; set; }
    public int TotalCompletadas { get; set; }
    public IEnumerable<ActividadDto> Actividades { get; set; } = [];
}