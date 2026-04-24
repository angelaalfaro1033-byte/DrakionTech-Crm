namespace DrakionTech.Crm.Business.DTOs.UsuarioInterno
{
    public class UsuarioInternoDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;
        public string? Apellido { get; set; }

        public string? Email { get; set; }
        public string? Telefono { get; set; }

        public bool Activo { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}