namespace DrakionTech.Crm.Business.DTOs.RolUsuario
{
    public class RolUsuarioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public bool Activo { get; set; } = true;
    }
}