using EDiaristas.Core.Models;
using EDiaristas.Core.Repositories.Diarias;
using EDiaristas.Core.Services.GatewayPagamento;
using Sgbj.Cron;

namespace EDiaristas.Core.Tasks;

public class CancelarDiariasTask : BackgroundService
{
    private readonly string _cronExpression;
    private readonly ILogger<CancelarDiariasTask> _logger;
    private readonly IServiceProvider _serviceProvider;

    public CancelarDiariasTask(
        IConfiguration configuration,
        IServiceProvider serviceProvider,
        ILogger<CancelarDiariasTask> logger)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
        _cronExpression = configuration.GetValue<string>("Tasks:CancelarDiariasTask:CronExpression");
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var timer = new CronTimer(_cronExpression);
        while (await timer.WaitForNextTickAsync())
        {
            _logger.LogInformation("CancelarDiariasTask is running.");
            using (var scope = _serviceProvider.CreateScope())
            {
                var diariaRepository = scope.ServiceProvider.GetRequiredService<IDiariaRepository>();
                var gatewayPagamentoService = scope.ServiceProvider.GetRequiredService<IGatewayPagamentoService>();
                diariaRepository.FindAptasParaCancelamento().ToList().ForEach(diaria =>
                {
                    _logger.LogInformation($"Cancelando diaria {diaria.Id}");
                    if (diaria.Status == DiariaStatus.Pago)
                    {
                        _logger.LogInformation($"Reembolsando pagamento da diária {diaria.Id}");
                        try
                        {
                            gatewayPagamentoService.Estornar(diaria);
                        }
                        catch (GatewayPagamentoServiceException e)
                        {
                            _logger.LogError(e, $"Erro ao reembolsar pagamento da diária {diaria.Id}");
                        }
                    }
                    diaria.Status = DiariaStatus.Cancelado;
                    diariaRepository.Update(diaria);
                    _logger.LogInformation($"Diaria {diaria.Id} cancelada");
                });
            }
            _logger.LogInformation("CancelarDiariasTask is finished.");
        }
    }
}