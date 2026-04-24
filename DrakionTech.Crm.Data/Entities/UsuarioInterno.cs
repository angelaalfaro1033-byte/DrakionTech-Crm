namespace DrakionTech.Crm.Data.Entities
{
    public class UsuarioInterno
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;
        public string? Apellido { get; set; }

        public string? Email { get; set; }
        public string? Telefono { get; set; }

        public bool Activo { get; set; } = true;

        // FUTURO LOGIN
        public string? IdentityUserId { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        // RELACIONES
        public ICollection<Actividad> ActividadesResponsable { get; set; }
            = new List<Actividad>();

        public ICollection<ActividadUsuario> ActividadesAsignadas { get; set; }
            = new List<ActividadUsuario>();
    }
}