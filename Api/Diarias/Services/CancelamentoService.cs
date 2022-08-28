using EDiaristas.Api.Common.Dtos;
using EDiaristas.Api.Diarias.Dtos;
using EDiaristas.Core.Exceptions;
using EDiaristas.Core.Models;
using EDiaristas.Core.Repositories.Avaliacoes;
using EDiaristas.Core.Repositories.Diarias;
using EDiaristas.Core.Services.Authentication.Adapters;
using EDiaristas.Core.Services.GatewayPagamento;
using FluentValidation;

namespace EDiaristas.Api.Diarias.Services;

public class CancelamentoService : ICancelamentoService
{
    private readonly IDiariaRepository _diariaRepository;
    private readonly IAvaliacaoRepository _avaliacaoRepository;
    private readonly IGatewayPagamentoService _gatewayPagamentoService;
    private readonly IValidator<CancelamentoRequest> _canelamentoValidator;
    private readonly ICustomAuthenticationService _customAuthenticationService;

    public CancelamentoService(
        IDiariaRepository diariaRepository,
        IAvaliacaoRepository avaliacaoRepository,
        IGatewayPagamentoService gatewayPagamentoService,
        IValidator<CancelamentoRequest> canelamentoValidator,
        ICustomAuthenticationService customAuthenticationService)
    {
        _diariaRepository = diariaRepository;
        _avaliacaoRepository = avaliacaoRepository;
        _gatewayPagamentoService = gatewayPagamentoService;
        _canelamentoValidator = canelamentoValidator;
        _customAuthenticationService = customAuthenticationService;
    }

    public MessageResponse Cancelar(int diariaId, CancelamentoRequest cancelamentoRequest)
    {
        var diaria = _diariaRepository.FindById(diariaId);
        if (diaria is null)
        {
            throw new DiariaNotFoundException();
        }
        cancelamentoRequest.Diaria = diaria;
        _canelamentoValidator.ValidateAndThrow(cancelamentoRequest);
        if (hasPenalizacao(diaria))
        {
            aplicarPenalizacao(diaria);
        }
        else
        {
            _gatewayPagamentoService.Estornar(diaria);
        }
        diaria.Status = DiariaStatus.Cancelado;
        diaria.MotivoCancelamento = cancelamentoRequest.MotivoCancelamento;
        _diariaRepository.Update(diaria);
        return new MessageResponse("Diária cancelada com sucesso");
    }

    private void aplicarPenalizacao(Diaria diaria)
    {
        var usuarioAutenticado = _customAuthenticationService.GetUsuarioAutenticado();
        if (usuarioAutenticado.TipoUsuario == TipoUsuario.Diarista)
        {
            penalizarDiarista(diaria);
            _gatewayPagamentoService.Estornar(diaria);
        }
        else
        {
            _gatewayPagamentoService.Estornar(diaria, diaria.Preco / (decimal)2);
        }
    }

    private void penalizarDiarista(Diaria diaria)
    {
        if (diaria.Diarista is null)
        {
            throw new ArgumentException("Diária não possui diarista");
        }
        var avaliacao = new Avaliacao
        {
            Nota = 1,
            Descricao = "Penalização diária cancelada",
            AvaliadoId = diaria.Diarista.Id,
            Visibilidade = false,
            Diaria = diaria
        };
        _avaliacaoRepository.Create(avaliacao);
    }

    private bool hasPenalizacao(Diaria diaria)
    {
        var horas = (diaria.DataAtendimento - DateTime.Now).TotalHours;
        return horas < 24;
    }
}