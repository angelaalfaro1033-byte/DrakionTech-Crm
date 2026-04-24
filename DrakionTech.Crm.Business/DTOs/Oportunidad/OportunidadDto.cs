namespace DrakionTech.Crm.Business.DTOs.Oportunidad
{
    public class OportunidadDto
    {
        public int Id { get; set; }

        public int EmpresaId { get; set; }
        public string EmpresaNombre { get; set; } = null!;

        public int? ContactoPrincipalId { get; set; }
        public string? ContactoPrincipalNombre { get; set; }

        public string NombreProyecto { get; set; } = null!;
        public decimal ValorEstimado { get; set; }

        public int Etapa { get; set; }
        public string EtapaNombre { get; set; } = string.Empty;

        public DateTime? FechaEstimadaCierre { get; set; }
        public string? Descripcion { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}