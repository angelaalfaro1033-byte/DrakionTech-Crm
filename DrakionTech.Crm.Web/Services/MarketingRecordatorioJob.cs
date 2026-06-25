using DrakionTech.Crm.Business.Services.Marketing;

namespace DrakionTech.Crm.Web.Services;

public class MarketingRecordatorioJob : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<MarketingRecordatorioJob> _logger;
    private static readonly TimeSpan Intervalo = TimeSpan.FromHours(1);

    public MarketingRecordatorioJob(
        IServiceScopeFactory scopeFactory,
        ILogger<MarketingRecordatorioJob> logger)
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
                    .GetRequiredService<IMarketingRecordatorioService>();

                await servicio.ProcesarRecordatoriosAsync(stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al procesar recordatorios de marketing");
            }

            await Task.Delay(Intervalo, stoppingToken);
        }
    }
}