namespace DrakionTech.Crm.Business.DTOs.Area;

public class AreaListDto : DrakionTech.Crm.Business.DTOs.IHasAuditInfo
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public bool Activa { get; set; }
    public int? ResponsableId { get; set; }
    public string? ResponsableNombre { get; set; }
    public DateTime FechaCreacion { get; set; }
    public int TotalUsuarios { get; set; }
    public DrakionTech.Crm.Business.DTOs.AuditInfoDto? AuditInfo { get; set; }
}
