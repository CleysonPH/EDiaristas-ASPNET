using EDiaristas.Core.Models;
using EDiaristas.Core.Repositories.Diarias;
using EDiaristas.Core.Services.DiaristaIndice.Adapters;
using EDiaristas.Core.Services.Email;
using Sgbj.Cron;

namespace EDiaristas.Core.Tasks;

public class SelecionarDiaristaTask : BackgroundService
{
    private readonly string _cronExpression;
    private readonly ILogger<SelecionarDiaristaTask> _logger;
    private readonly IServiceProvider _serviceProvider;

    public SelecionarDiaristaTask(
        IConfiguration configuration,
        IServiceProvider serviceProvider,
        ILogger<SelecionarDiaristaTask> logger)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
        _cronExpression = configuration.GetValue<string>("Tasks:SelecionarDiaristaTask:CronExpression");
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var timer = new CronTimer(_cronExpression);
        while (await timer.WaitForNextTickAsync())
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var diariaRepository = scope.ServiceProvider.GetRequiredService<IDiariaRepository>();
                var diaristaIndiceService = scope.ServiceProvider.GetRequiredService<IDiaristaIndiceService>();
                var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();

                _logger.LogInformation("SelecionarDiaristaTask is running.");
                var diarias = diariaRepository.FindAptasParaSelecao();
                foreach (var diaria in diarias)
                {
                    var diarista = diaristaIndiceService.SelecionarMelhorDiarista(diaria);
                    diaria.Diarista = diarista;
                    diaria.Status = DiariaStatus.Confirmado;
                    diariaRepository.Update(diaria);
                    _logger.LogInformation($"Diaria {diaria.Id} selecionada para {diarista.NomeCompleto}");
                    enviarEmailDeDiariaSelecionada(diaria, emailService);
                }
                _logger.LogInformation("SelecionarDiaristaTask is finished.");
            }
        }
    }

    private void enviarEmailDeDiariaSelecionada(Diaria diaria, IEmailService emailService)
    {
        emailService.EnviarAsync(new EmailParams(
            destinatario: diaria.Cliente.Email,
            assunto: "Diarista selecionado",
            template: EmailParams.TemplateOptions.DiaristaSelecionado,
            props: new Dictionary<string, string>{
                { "NomeCompleto", diaria.Cliente.NomeCompleto },
                { "TipoUsuario", diaria.Cliente.TipoUsuario.ToString() }
            }
        ));
        emailService.EnviarAsync(new EmailParams(
            destinatario: diaria.Diarista?.Email ?? "",
            assunto: "Diária selecionada",
            template: EmailParams.TemplateOptions.DiaristaSelecionado,
            props: new Dictionary<string, string>{
                { "NomeCompleto", diaria.Diarista?.NomeCompleto ?? "" },
                { "TipoUsuario", diaria.Diarista?.TipoUsuario.ToString() ?? "" }
            }
        ));
    }
}