using DrakionTech.Crm.Data.Entities.Enums;

namespace DrakionTech.Crm.Data.Entities
{
    public class Empleado : DrakionTech.Crm.Data.Entities.Base.AuditableEntity
    {
        public int Id { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public string? NumeroDocumento { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int? RolUsuarioId { get; set; }
        public int? EspecialidadId { get; set; }
        public bool Activo { get; set; } = true;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime? FechaModificacion { get; set; }
        public string? PasswordHash { get; set; }
        public bool IsActive { get; set; } = false;
        public string? ActivationToken { get; set; }
        public DateTime? ActivationTokenExpiration { get; set; }
        public EmpleadoSalario? Salario { get; set; }
        public RolUsuario? RolUsuario { get; set; }
        public Especialidad? EspecialidadNavigation { get; set; }
    }
}
