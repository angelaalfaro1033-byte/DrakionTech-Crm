using DrakionTech.Crm.Business.Services.Empresas;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DrakionTech.Crm.Web.Services;

public class EmpresaAniversarioJob : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<EmpresaAniversarioJob> _logger;
    private static readonly TimeSpan Intervalo = TimeSpan.FromHours(1);

    public EmpresaAniversarioJob(
        IServiceScopeFactory scopeFactory,
        ILogger<EmpresaAniversarioJob> logger)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = _scopeFactory.CreateScope();
                var servicio = scope.ServiceProvider
                    .GetRequiredService<IEmpresaAniversarioService>();

                await servicio.ProcesarAniversariosAsync(stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al procesar los aniversarios de empresas");
            }

            await Task.Delay(Intervalo, stoppingToken);
        }
    }
}