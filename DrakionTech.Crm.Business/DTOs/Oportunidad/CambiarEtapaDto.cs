using DrakionTech.Crm.Data.Entities.Enums;

namespace DrakionTech.Crm.Business.DTOs.Oportunidad;
public class CambiarEtapaDto
{
    public int OportunidadId { get; set; }
    public EtapaOportunidad NuevaEtapa { get; set; }
    public int? UsuarioId { get; set; }
    public int? AreaId { get; set; }
    public int? ResponsableId { get; set; }
}