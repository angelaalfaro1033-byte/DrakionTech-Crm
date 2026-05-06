namespace DrakionTech.Crm.Business.DTOs.Usuario;

public class UsuarioListDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Telefono { get; set; }
    public string Rol { get; set; } = null!;
    public bool IsActive { get; set; }
}