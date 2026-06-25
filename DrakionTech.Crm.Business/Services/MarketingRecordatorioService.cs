using DrakionTech.Crm.Business.Services.Email;
using DrakionTech.Crm.Data.Entities.Enums;
using DrakionTech.Crm.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DrakionTech.Crm.Business.Services.Marketing;

public interface IMarketingRecordatorioService
{
    Task ProcesarRecordatoriosAsync(CancellationToken ct = default);
}

public class MarketingRecordatorioService : IMarketingRecordatorioService
{
    private readonly IPublicacionMarketingRepository _repo;
    private readonly IEmailService _email;
    private readonly IMarketingTokenService _tokens;
    private readonly string _baseUrl;

    public MarketingRecordatorioService(
        IPublicacionMarketingRepository repo,
        IEmailService email,
        IMarketingTokenService tokens,
        IConfiguration config)
    {
        _repo = repo;
        _email = email;
        _tokens = tokens;
        _baseUrl = config["App:BaseUrl"]
            ?? throw new InvalidOperationException("App:BaseUrl no configurado");
    }

    public async Task ProcesarRecordatoriosAsync(CancellationToken ct = default)
    {
        var hoy = DateTime.Today;
        var ayer = hoy.AddDays(-1);
        var diasAntes = hoy.AddDays(3);

        var publicaciones = await _repo.Query()
            .Include(p => p.Responsable)
            .Where(p => p.Estado == EstadoPublicacionMarketing.Programada)
            .Where(p =>
                // Día anterior — aún no enviado
                (!p.Recordatorio3DiasEnviado &&
                 p.FechaPublicacionProgramada.Date == diasAntes) ||
                // Día de publicación — aún no enviado
                (!p.RecordatorioDiaPublicacionEnviado &&
                 p.FechaPublicacionProgramada.Date == hoy) ||
                // Día siguiente — aún no enviado
                (!p.AlertaRetrasoEnviada &&
                 p.FechaPublicacionProgramada.Date == ayer))
            .ToListAsync(ct);

        foreach (var pub in publicaciones)
        {
            var correo = pub.Responsable?.Email;
            if (string.IsNullOrWhiteSpace(correo)) continue;

            var fecha = pub.FechaPublicacionProgramada.ToString("dd/MM/yyyy");

            // ── Recordatorio día anterior ─────────────────────
            if (!pub.Recordatorio3DiasEnviado &&
                pub.FechaPublicacionProgramada.Date == diasAntes)
            {
                await _email.EnviarPlantillaAsync(correo,
                    "marketing-recordatorio-dia-anterior",
                    new Dictionary<string, string>
                    {
                        ["nombre"] = pub.Nombre,
                        ["fecha"] = fecha,
                        ["responsable"] = pub.Responsable!.Nombre
                    });

                pub.Recordatorio3DiasEnviado = true;
            }

            // ── Recordatorio día de publicación ───────────────
            if (!pub.RecordatorioDiaPublicacionEnviado &&
                pub.FechaPublicacionProgramada.Date == hoy)
            {
                await _email.EnviarPlantillaAsync(correo,
                    "marketing-recordatorio-hoy",
                    new Dictionary<string, string>
                    {
                        ["nombre"] = pub.Nombre,
                        ["fecha"] = fecha,
                        ["responsable"] = pub.Responsable!.Nombre
                    });

                pub.RecordatorioDiaPublicacionEnviado = true;
            }

            // ── Alerta día siguiente (con formulario) ─────────
            if (!pub.AlertaRetrasoEnviada &&
                pub.FechaPublicacionProgramada.Date == ayer)
            {
                var token = _tokens.GenerarToken(pub.Id);
                var urlFormulario = $"{_baseUrl}/marketing/confirmar-publicacion/{token}";

                await _email.EnviarPlantillaAsync(correo,
                    "marketing-alerta-retraso",
                    new Dictionary<string, string>
                    {
                        ["nombre"] = pub.Nombre,
                        ["fecha"] = fecha,
                        ["responsable"] = pub.Responsable!.Nombre,
                        ["url_formulario"] = urlFormulario
                    });

                pub.AlertaRetrasoEnviada = true;
            }

            await _repo.ActualizarAsync(pub);
        }
    }
}