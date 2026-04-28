using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using DrakionTech.Crm.Business.Configurations;

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
            throw new Exception("ERROR SMTP: destinatario (to) está vacío");

        if (string.IsNullOrWhiteSpace(_settings.From))
            throw new Exception("ERROR SMTP: From está vacío");

        if (string.IsNullOrWhiteSpace(_settings.User))
            throw new Exception("ERROR SMTP: User está vacío");

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