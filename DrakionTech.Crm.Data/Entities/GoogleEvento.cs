using DrakionTech.Crm.Data.Entities;

public class GoogleEvento
{
    public int Id { get; set; }

    public string? GoogleEventId { get; set; }

    public string? Titulo { get; set; }
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }

    public string? Descripcion { get; set; }
    public string? Ubicacion { get; set; }

    public int? EmpresaId { get; set; }
    public string? EmpresaNombre { get; set; }
    public string? EmpresaNit { get; set; }

    public bool Sincronizado { get; set; } = false;

    public DateTime FechaImportacion { get; set; } = DateTime.Now;

    public DateTime? LastUpdatedGoogle { get; set; }

    public List<GoogleEventoArchivo> Archivos { get; set; } = new();
}