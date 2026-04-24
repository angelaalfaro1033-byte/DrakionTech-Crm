namespace DrakionTech.Crm.Business.DTOs.Ubicacion
{
    public class CiudadDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int PaisId { get; set; }
    }
}