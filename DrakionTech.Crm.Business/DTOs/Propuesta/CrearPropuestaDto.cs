namespace DrakionTech.Crm.Business.DTOs.Propuesta
{
    public class CrearPropuestaDto
    {
        public int OportunidadId { get; set; }
        public string NombreArchivo { get; set; } = null!;
        public string RutaArchivo { get; set; } = null!;
        public string TipoContenido { get; set; } = null!;
        public long TamanoArchivo { get; set; }
    }
}