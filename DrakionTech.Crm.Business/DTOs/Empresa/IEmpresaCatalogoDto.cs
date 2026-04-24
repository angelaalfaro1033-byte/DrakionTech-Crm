namespace DrakionTech.Crm.Business.DTOs.Empresa
{
    public interface IEmpresaCatalogoDto
    {
        int? SectorId { get; }
        string? SectorOtro { get; }

        int? EstadoId { get; }
        string? EstadoOtro { get; }
    }
}