using DrakionTech.Crm.Data.Entities.Base;

namespace DrakionTech.Crm.Data.Entities
{
    public class Ciudad : BaseCatalogEntity
    {
        public int PaisId { get; set; }
        public Pais Pais { get; set; } = null!;
    }
}