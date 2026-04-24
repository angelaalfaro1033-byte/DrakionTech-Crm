using System.Threading.Tasks;

namespace DrakionTech.Crm.Business.Interfaces
{
    public interface IWhatsAppNotificationService
    {
        Task EnviarTemplateAsync(string numero, string template, params string[] parametros);
    }
}