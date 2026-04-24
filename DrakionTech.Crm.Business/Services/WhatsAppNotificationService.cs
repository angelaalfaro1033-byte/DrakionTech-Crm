using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using DrakionTech.Crm.Business.Interfaces;
using DrakionTech.Crm.Business.Options;

namespace DrakionTech.Crm.Business.Services
{
    public class WhatsAppNotificationService : IWhatsAppNotificationService
    {
        private readonly HttpClient _httpClient;
        private readonly WhatsAppOptions _options;

        public WhatsAppNotificationService(
            HttpClient httpClient,
            IOptions<WhatsAppOptions> options)
        {
            _httpClient = httpClient;
            _options = options.Value;
        }

        public async Task EnviarTemplateAsync(string numero, string template, params string[] parametros)
        {
            var url = $"https://graph.facebook.com/v22.0/{_options.PhoneNumberId}/messages";

            object payload;

            if (parametros == null || parametros.Length == 0)
            {
                payload = new
                {
                    messaging_product = "whatsapp",
                    to = numero,
                    type = "template",
                    template = new
                    {
                        name = template,
                        language = new { code = "en_US" }
                    }
                };
            }
            else
            {
                payload = new
                {
                    messaging_product = "whatsapp",
                    to = numero,
                    type = "template",
                    template = new
                    {
                        name = template,
                        language = new { code = "es_CO" },
                        components = new object[]
                        {
                            new
                            {
                                type = "body",
                                parameters = parametros.Select(p => new
                                {
                                    type = "text",
                                    text = p
                                })
                            }
                        }
                    }
                };
            }

            var request = new HttpRequestMessage(HttpMethod.Post, url);

            request.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", _options.Token);

            request.Content = new StringContent(
                JsonSerializer.Serialize(payload),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.SendAsync(request);

            var result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"WhatsApp error: {result}");
            }
        }
    }
}