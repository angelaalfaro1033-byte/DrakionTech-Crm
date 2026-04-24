namespace DrakionTech.Crm.Data.Entities
{
    public class Propuesta
    {
        public int Id { get; set; }

        public int OportunidadId { get; set; }

        public string NombreArchivo { get; set; } = null!;

        public string RutaArchivo { get; set; } = null!;

        public string TipoContenido { get; set; } = null!;

        public long TamanoArchivo { get; set; }

        public DateTime FechaCarga { get; set; } = DateTime.UtcNow;

        public Oportunidad Oportunidad { get; set; } = null!;
    }
}