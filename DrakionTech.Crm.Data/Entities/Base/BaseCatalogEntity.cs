namespace DrakionTech.Crm.Data.Entities.Base
{
    public abstract class BaseCatalogEntity : AuditableEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
    }
}
