using DrakionTech.Crm.Data.Entities.Base;

namespace DrakionTech.Crm.Data.Entities
{
    public class Pais : BaseCatalogEntity
    {
        public string CodigoIso { get; set; } = null!;

        public ICollection<Ciudad> Ciudades { get; set; } = [];
        public ICollection<PrefijoTelefonico> PrefijosTelefonicos { get; set; } = [];
    }
}