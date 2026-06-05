namespace DrakionTech.Crm.Data.Entities
{
    public class EmpresaCorreo
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public bool EsPrincipal { get; set; }
    }
}