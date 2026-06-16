namespace DrakionTech.Crm.Business.DTOs.RolUsuario
{
    public class RolUsuarioDto : DrakionTech.Crm.Business.DTOs.IHasAuditInfo
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public bool Activo { get; set; } = true;
        public DrakionTech.Crm.Business.DTOs.AuditInfoDto? AuditInfo { get; set; }
    }
}
