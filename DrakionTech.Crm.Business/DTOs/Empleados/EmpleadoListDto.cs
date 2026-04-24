namespace DrakionTech.Crm.Business.DTOs.Empleado
{
    public class EmpleadoListDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Cargo { get; set; } = null!;   

        public string Rol { get; set; } = null!;
        public bool Activo { get; set; }
    }
}