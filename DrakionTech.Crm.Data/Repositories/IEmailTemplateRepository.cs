using DrakionTech.Crm.Data.Entities;

public interface IEmailTemplateRepository
{
    Task<EmailTemplate?> GetByNombreAsync(string nombre);
}