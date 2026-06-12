namespace DrakionTech.Crm.Data.Entities
{
    public class EmpleadoSalario : DrakionTech.Crm.Data.Entities.Base.AuditableEntity
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public decimal Salario { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public DateTime? FechaModificacion { get; set; }

        public Empleado Empleado { get; set; } = null!;
    }
}
