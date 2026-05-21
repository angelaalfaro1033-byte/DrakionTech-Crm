using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using DrakionTech.Crm.Business.Configurations;
using DrakionTech.Crm.Business.Common;

namespace DrakionTech.Crm.Business.Services.Email;

public class SmtpEmailSender : IEmailSender
{
    private readonly EmailSettings _settings;

    public SmtpEmailSender(IOptions<EmailSettings> settings)
    {
        _settings = settings.Value;
    }

    public async Task SendAsync(string to, string subject, string html)
    {

        if (string.IsNullOrWhiteSpace(to))
            throw new Exception(MensajesError.DestinatarioVacio);

        if (string.IsNullOrWhiteSpace(_settings.From))
            throw new Exception(MensajesError.DesdeVacio);

        if (string.IsNullOrWhiteSpace(_settings.User))
            throw new Exception(MensajesError.UsuarioVacio);

        using var client = new SmtpClient(_settings.SmtpServer, _settings.Port)
        {
            Credentials = new NetworkCredential(_settings.User, _settings.Password),
            EnableSsl = true
        };

        var mail = new MailMessage
        {
            From = new MailAddress(_settings.From),
            Subject = subject,
            Body = html,
            IsBodyHtml = true
        };

        mail.To.Add(to);

        await client.SendMailAsync(mail);
    }
}