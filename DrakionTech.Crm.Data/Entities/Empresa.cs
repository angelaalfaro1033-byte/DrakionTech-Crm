namespace DrakionTech.Crm.Data.Entities
{
    public class Empresa
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Nit { get; set; } = null!;

        public string Direccion { get; set; } = null!;
        public string? Correo { get; set; }

        public int PaisId { get; set; }
        public Pais Pais { get; set; } = null!;

        public int CiudadId { get; set; }
        public Ciudad Ciudad { get; set; } = null!;

        public int? SectorId { get; set; }
        public Sector? Sector { get; set; }
        public string? SectorOtro { get; set; }

        public int? EstadoId { get; set; }
        public Estado? Estado { get; set; }
        public string? EstadoOtro { get; set; }

        public string? RepresentanteLegal { get; set; }

        public string? Telefono { get; set; }

        public DateTime FechaVinculacion { get; set; }

        public bool HaTrabajadoAntes { get; set; }

        public DateTime? FechaEspecial { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        public ICollection<Contacto> Contactos { get; set; } = new List<Contacto>();
        public ICollection<Oportunidad> Oportunidades { get; set; } = new List<Oportunidad>();
        public ICollection<Actividad> Actividades { get; set; } = new List<Actividad>();
    }
}