namespace DrakionTech.Crm.Business.DTOs.Google
{
    public class GoogleEventoDto
    {
        public string? GoogleEventId { get; set; }
        public string? Titulo { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string? Descripcion { get; set; }
        public string? Ubicacion { get; set; }
        public List<string> Archivos { get; set; } = new();
        public DateTime? LastUpdatedGoogle { get; set; }

    }
}