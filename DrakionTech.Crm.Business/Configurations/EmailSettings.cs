namespace DrakionTech.Crm.Business.Configurations;

public class EmailSettings
{
    public string SmtpServer { get; set; } = null!;
    public int Port { get; set; }
    public string User { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string From { get; set; } = null!;
}