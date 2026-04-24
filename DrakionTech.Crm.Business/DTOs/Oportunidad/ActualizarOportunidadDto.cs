namespace DrakionTech.Crm.Business.DTOs.Oportunidad
{
    public class ActualizarOportunidadDto
    {
        public string NombreProyecto { get; set; } = null!;
        public decimal ValorEstimado { get; set; }
        public DateTime? FechaEstimadaCierre { get; set; }
        public string? Descripcion { get; set; }
    }
}