namespace DrakionTech.Crm.Business.Services.Email;

public interface IEmailService
{
    Task EnviarPlantillaAsync(string to, string templateName, Dictionary<string, string> values);
}