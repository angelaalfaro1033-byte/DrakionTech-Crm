using DrakionTech.Crm.Business.Common;
using DrakionTech.Crm.Data.Repositories.Interfaces;

namespace DrakionTech.Crm.Business.Services.Email;

public class EmailService : IEmailService
{
    private readonly IEmailTemplateRepository _repo;
    private readonly IEmailTemplateRenderer _renderer;
    private readonly IEmailSender _sender;

    public EmailService(
        IEmailTemplateRepository repo,
        IEmailTemplateRenderer renderer,
        IEmailSender sender)
    {
        _repo = repo;
        _renderer = renderer;
        _sender = sender;
    }

    public async Task EnviarPlantillaAsync(string to, string templateName, Dictionary<string, string> values)
    {
        var template = await _repo.ObtenerPorNombreAsync(templateName);

        if (template == null)
            throw new Exception(MensajesError.PlantinaNoExiste);

        var body = _renderer.Render(template.TemplateHtml, values);

        await _sender.SendAsync(to, templateName, body);
    }
}