using DrakionTech.Crm.Data.Entities.Base;

namespace DrakionTech.Crm.Data.Entities
{
    public class PrefijoTelefonico : BaseCatalogEntity
    {
        public string Codigo { get; set; } = null!;

        public int PaisId { get; set; }
        public Pais Pais { get; set; } = null!;
    }
}