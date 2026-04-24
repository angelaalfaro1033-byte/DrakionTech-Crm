namespace DrakionTech.Crm.Data.Entities
{
    public class GoogleEventoArchivo
    {
        public int Id { get; set; }

        public int GoogleEventoId { get; set; }
        public GoogleEvento GoogleEvento { get; set; } = null!;

        public string Url { get; set; } = null!;
        public string? Nombre { get; set; }
        public string GoogleFileId { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}