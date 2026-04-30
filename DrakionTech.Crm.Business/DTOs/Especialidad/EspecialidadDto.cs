namespace DrakionTech.Crm.Business.DTOs.Especialidad
{
    public class EspecialidadDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int RolUsuarioId { get; set; }
        public string? RolUsuarioNombre { get; set; }
        public bool Activo { get; set; } = true;
    }
}