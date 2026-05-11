namespace DrakionTech.Crm.Business.DTOs.Actividad
{
    public class DashboardActividadDto
    {
        public int TotalVencidas { get; set; }
        public int TotalProximasAVencer { get; set; }
        public int TotalPendientes { get; set; }
        public IEnumerable<ActividadDto> Actividades { get; set; } = [];
    }
}