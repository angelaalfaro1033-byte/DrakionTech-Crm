namespace DrakionTech.Crm.Business.Services.Email;

public interface IEmailTemplateRenderer
{
    string Render(string template, Dictionary<string, string> values);
}

public class EmailTemplateRenderer : IEmailTemplateRenderer
{
    public string Render(string template, Dictionary<string, string> values)
    {
        foreach (var item in values)
        {
            template = template.Replace($"{{{{{item.Key}}}}}", item.Value);
        }

        return template;
    }
}