using EDiaristas.Core.Models;
using EDiaristas.Core.Repositories.Diarias;
using EDiaristas.Core.Services.DiaristaIndice.Adapters;
using Sgbj.Cron;

namespace EDiaristas.Core.Tasks;

public class SelecionarDiaristaTask : BackgroundService
{
    private readonly string _cronExpression;
    private readonly IDiariaRepository _diariaRepository;
    private readonly IDiaristaIndiceService _diaristaIndiceService;
    private readonly ILogger<SelecionarDiaristaTask> _logger;

    public SelecionarDiaristaTask(
        IDiariaRepository diariaRepository,
        ILogger<SelecionarDiaristaTask> logger,
        IDiaristaIndiceService diaristaIndiceService,
        IConfiguration configuration)
    {
        _logger = logger;
        _diariaRepository = diariaRepository;
        _diaristaIndiceService = diaristaIndiceService;
        _cronExpression = configuration.GetValue<string>("Tasks:SelecionarDiaristaTask:CronExpression");
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var timer = new CronTimer(_cronExpression);
        while (await timer.WaitForNextTickAsync())
        {
            _logger.LogInformation("SelecionarDiaristaTask is running.");
            var diarias = _diariaRepository.FindAptasParaSelecao();
            foreach (var diaria in diarias)
            {
                var diarista = _diaristaIndiceService.SelecionarMelhorDiarista(diaria);
                diaria.Diarista = diarista;
                diaria.Status = DiariaStatus.Confirmado;
                _diariaRepository.Update(diaria);
                _logger.LogInformation($"Diaria {diaria.Id} selecionada para {diarista.NomeCompleto}");
            }
            _logger.LogInformation("SelecionarDiaristaTask is finished.");
        }
    }
}