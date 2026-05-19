namespace DrakionTech.Crm.Business.DTOs.Empleado
{
    public class ImportarEmpleadosResultDto
    {
        public int Creados { get; set; }
        public int Actualizados { get; set; }
        public List<string> Errores { get; set; } = new();
    }
}