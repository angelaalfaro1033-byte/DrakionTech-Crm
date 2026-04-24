using DrakionTech.Crm.Data.Entities.Base;

namespace DrakionTech.Crm.Data.Entities
{
    public class TipoActividad : BaseCatalogEntity
    {
        public string? Descripcion { get; set; }
        public bool Activo { get; set; } = true;

        public ICollection<Actividad> Actividades { get; set; }
            = new List<Actividad>();
    }
}