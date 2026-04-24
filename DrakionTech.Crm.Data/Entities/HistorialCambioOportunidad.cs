using DrakionTech.Crm.Data.Entities.Enums;

namespace DrakionTech.Crm.Data.Entities
{
    public class HistorialCambioOportunidad
    {
        public int Id { get; set; } 

        public int OportunidadId { get; set; }

        public EtapaOportunidad EtapaAnterior { get; set; }

        public EtapaOportunidad EtapaNueva { get; set; }

        public DateTime FechaCambio { get; set; } = DateTime.UtcNow;

        public int? UsuarioId { get; set; }

        public Oportunidad Oportunidad { get; set; } = null!;
    }
}