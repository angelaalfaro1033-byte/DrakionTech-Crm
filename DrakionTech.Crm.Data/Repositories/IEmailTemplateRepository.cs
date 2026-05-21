using DrakionTech.Crm.Data.Entities;

public interface IEmailTemplateRepository
{
    Task<EmailTemplate?> ObtenerPorNombreAsync(string nombre);
}