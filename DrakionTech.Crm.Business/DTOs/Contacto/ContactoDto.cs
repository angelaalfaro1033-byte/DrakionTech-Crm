namespace DrakionTech.Crm.Business.DTOs.Contacto
{
    public class ContactoDto
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public string EmpresaNombre { get; set; } = null!;

        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string NombreCompleto => $"{Nombre} {Apellido}";

        public string? Email { get; set; }
        public string? Telefono { get; set; }

        public int RolContactoId { get; set; }
        public string RolNombre { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; }
    }
}