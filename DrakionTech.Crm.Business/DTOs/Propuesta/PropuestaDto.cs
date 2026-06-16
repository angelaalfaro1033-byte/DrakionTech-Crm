namespace DrakionTech.Crm.Business.DTOs.Propuesta
{
    public class PropuestaDto : DrakionTech.Crm.Business.DTOs.IHasAuditInfo
    {
        public int Id { get; set; }
        public int OportunidadId { get; set; }
        public string NombreArchivo { get; set; } = null!;
        public string RutaArchivo { get; set; } = null!;
        public DateTime FechaCarga { get; set; }
        public DrakionTech.Crm.Business.DTOs.AuditInfoDto? AuditInfo { get; set; }
    }
}
