namespace DrakionTech.Crm.Api.DTOs
{
    public class UsuarioInfoDto
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; } = null!;
        public string Rol { get; set; } = null!;
    }
}