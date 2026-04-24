using DrakionTech.Crm.Data.Entities.Base;

namespace DrakionTech.Crm.Data.Entities
{
    public class EstadoActividad : BaseCatalogEntity
    {
        public bool Activo { get; set; } = true;

        public ICollection<Actividad> Actividades { get; set; }
            = new List<Actividad>();
    }
}