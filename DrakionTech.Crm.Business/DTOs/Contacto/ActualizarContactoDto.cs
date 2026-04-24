namespace DrakionTech.Crm.Business.DTOs.Contacto
{
    public class ActualizarContactoDto
    {
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string? Email { get; set; }
        public string? Telefono { get; set; }

        public int RolContactoId { get; set; }
    }
}