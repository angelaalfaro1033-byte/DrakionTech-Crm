using DrakionTech.Crm.Data.Entities.Base;

namespace DrakionTech.Crm.Data.Entities
{
    public class Especialidad : BaseCatalogEntity
    {
        public string? Descripcion { get; set; }
        public int RolUsuarioId { get; set; }
        public bool Activo { get; set; } = true;

        public RolUsuario RolUsuario { get; set; } = null!;
    }
}