namespace DrakionTech.Crm.Data.Entities
{
    public class EmailTemplate
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string TemplateHtml { get; set; } = null!;

        public bool Activo { get; set; } = true;
    }
}