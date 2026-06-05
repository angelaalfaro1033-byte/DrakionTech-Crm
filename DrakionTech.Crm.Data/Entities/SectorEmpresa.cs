using DrakionTech.Crm.Data.Entities.Base;

namespace DrakionTech.Crm.Data.Entities
{
    public class SectorEmpresa : BaseCatalogEntity
    {
        public ICollection<SubsectorEmpresa> Subsectores { get; set; } = new List<SubsectorEmpresa>();
        public ICollection<Empresa> Empresas { get; set; } = new List<Empresa>();
    }
}