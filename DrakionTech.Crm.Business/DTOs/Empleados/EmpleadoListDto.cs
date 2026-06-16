using DrakionTech.Crm.Data.Entities.Enums;

namespace DrakionTech.Crm.Business.DTOs.Empleado
{
    public class EmpleadoListDto : DrakionTech.Crm.Business.DTOs.IHasAuditInfo
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int? RolUsuarioId { get; set; }
        public int? EspecialidadId { get; set; }
        public string? RolNombre { get; set; }
        public string? Especialidad { get; set; }
        public bool Activo { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public string? NumeroDocumento { get; set; }
        public decimal? Salario { get; set; }
        public DrakionTech.Crm.Business.DTOs.AuditInfoDto? AuditInfo { get; set; }
    }
}
