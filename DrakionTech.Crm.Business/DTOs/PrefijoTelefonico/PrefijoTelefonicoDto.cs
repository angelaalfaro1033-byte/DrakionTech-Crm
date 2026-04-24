namespace DrakionTech.Crm.Business.DTOs.PrefijoTelefonico
{
    public class PrefijoTelefonicoDto
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public int PaisId { get; set; }
    }
}