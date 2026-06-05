using DrakionTech.Crm.Data.Entities.Base;

namespace DrakionTech.Crm.Data.Entities
{
    public class SubsectorEmpresa : BaseCatalogEntity
    {
        public ICollection<SectorEmpresa> Sectores { get; set; } = new List<SectorEmpresa>();
        public ICollection<Empresa> Empresas { get; set; } = new List<Empresa>();
    }
}