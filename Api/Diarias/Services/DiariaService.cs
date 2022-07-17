using EDiaristas.Api.Diarias.Dtos;
using EDiaristas.Api.Diarias.Mappers;
using EDiaristas.Core.Models;
using EDiaristas.Core.Repositories.Diarias;
using EDiaristas.Core.Repositories.Servicos;
using EDiaristas.Core.Services.Authentication.Adapters;
using FluentValidation;

namespace EDiaristas.Api.Diarias.Services;

public class DiariaService : IDiariaService
{
    private readonly IDiariaMapper _diariaMapper;
    private readonly IDiariaRepository _diariaRepository;
    private readonly IServicoRepository _servicoRepository;
    private readonly IValidator<DiariaRequest> _diariaRequestValidator;
    private readonly ICustomAuthenticationService _customAuthenticationService;

    public DiariaService(
        IDiariaMapper diariaMapper,
        IDiariaRepository diariaRepository,
        IValidator<DiariaRequest> diariaRequestValidator,
        IServicoRepository servicoRepository,
        ICustomAuthenticationService customAuthenticationService)
    {
        _diariaMapper = diariaMapper;
        _diariaRepository = diariaRepository;
        _diariaRequestValidator = diariaRequestValidator;
        _servicoRepository = servicoRepository;
        _customAuthenticationService = customAuthenticationService;
    }

    public DiariaResponse Cadastrar(DiariaRequest request)
    {
        _diariaRequestValidator.ValidateAndThrow(request);
        var diaria = _diariaMapper.ToModel(request);
        diaria.ValorComissao = calcularComissao(diaria);
        diaria.ClienteId = _customAuthenticationService.GetUsuarioAutenticado().Id;
        diaria.Status = DiariaStatus.SemPagamento;
        var diariaCadastrada = _diariaRepository.Create(diaria);
        return _diariaMapper.ToResponse(diariaCadastrada);
    }

    private decimal calcularComissao(Diaria diaria)
    {
        var servico = _servicoRepository.FindById(diaria.ServicoId);
        return diaria.Preco * (servico?.PorcentagemComissao / 100) ?? 0;
    }
}