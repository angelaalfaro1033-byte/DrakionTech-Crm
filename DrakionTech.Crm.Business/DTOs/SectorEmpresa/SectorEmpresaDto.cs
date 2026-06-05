namespace DrakionTech.Crm.Business.DTOs.SectorEmpresa
{
    public class SectorEmpresaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
    }

    public class SubsectorEmpresaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public List<int> SectorIds { get; set; } = new();
    }

    public class CrearSectorEmpresaDto
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Nombre { get; set; } = null!;
    }

    public class CrearSubsectorEmpresaDto
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Nombre { get; set; } = null!;
        public List<int> SectorIds { get; set; } = new();
    }
}