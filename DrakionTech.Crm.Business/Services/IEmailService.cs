namespace DrakionTech.Crm.Business.Services.Email;

public interface IEmailService
{
    Task SendTemplateAsync(string to, string templateName, Dictionary<string, string> values);
}