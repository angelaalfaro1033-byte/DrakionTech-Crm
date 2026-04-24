namespace DrakionTech.Crm.Business.DTOs.Google
{
    public class CrearGoogleEventoDto
    {
        public string Titulo { get; set; }
        public string? Descripcion { get; set; }
        public string? Ubicacion { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public List<ArchivoAdjuntoDto>? Archivos { get; set; }
        public List<string>? CorreosEmpleados { get; set; }
        public int? EmpresaId { get; set; }
        public string? EmpresaNombre { get; set; }
        public string? EmpresaNit { get; set; }

        public bool EsVirtual { get; set; }
    }

    public class ArchivoAdjuntoDto
    {
        public string Nombre { get; set; } = null!;
        public string MimeType { get; set; } = null!;
        public byte[] Contenido { get; set; } = null!;
    }
}