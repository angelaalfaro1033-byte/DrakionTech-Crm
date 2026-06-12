using DrakionTech.Crm.Data.Entities;

namespace DrakionTech.Crm.Data.Entities.Base
{
    public abstract class AuditableEntity
    {
        public int? CreatedByUserId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public int? ModifiedByUserId { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public Usuario? CreatedByUser { get; set; }
        public Usuario? ModifiedByUser { get; set; }
    }
}
