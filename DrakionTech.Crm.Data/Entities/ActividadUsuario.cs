namespace DrakionTech.Crm.Data.Entities
{
    public class ActividadUsuario
    {
        public int ActividadId { get; set; }
        public Actividad Actividad { get; set; } = null!;

        public int UsuarioInternoId { get; set; }
        public UsuarioInterno UsuarioInterno { get; set; } = null!;

        public bool EsResponsable { get; set; }
    }
}