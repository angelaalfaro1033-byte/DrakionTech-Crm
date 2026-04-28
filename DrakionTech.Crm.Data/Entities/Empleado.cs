namespace DrakionTech.Crm.Data.Entities
{
    public class Empleado
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;

        public string Email { get; set; } = null!;
        public string Cargo { get; set; } = null!;
        public string Rol { get; set; } = null!;

        public bool Activo { get; set; } = true;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime? FechaModificacion { get; set; }
        public string? PasswordHash { get; set; }

        public bool IsActive { get; set; } = false;

        public string? ActivationToken { get; set; }

        public DateTime? ActivationTokenExpiration { get; set; }
    }
}