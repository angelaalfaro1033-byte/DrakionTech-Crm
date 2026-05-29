namespace DrakionTech.Crm.Business.DTOs.Empleado
{
    public class EmpleadoExcelRowDto
    {
        public string TipoDocumento { get; set; } = null!;
        public string NumeroDocumento { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Rol { get; set; } = null!;
        public string Especialidad { get; set; } = null!;
        public decimal Salario { get; set; }
    }
}