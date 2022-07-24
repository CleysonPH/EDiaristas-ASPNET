using EDiaristas.Api.Common.Dtos;
using EDiaristas.Api.Diarias.Dtos;
using EDiaristas.Api.Diarias.Mappers;
using EDiaristas.Core.Exceptions;
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
    private readonly IValidator<PagamentoRequest> _pagamentoRequestValidator;

    public DiariaService(
        IDiariaMapper diariaMapper,
        IDiariaRepository diariaRepository,
        IValidator<DiariaRequest> diariaRequestValidator,
        IServicoRepository servicoRepository,
        ICustomAuthenticationService customAuthenticationService,
        IValidator<PagamentoRequest> pagamentoRequestValidator)
    {
        _diariaMapper = diariaMapper;
        _diariaRepository = diariaRepository;
        _diariaRequestValidator = diariaRequestValidator;
        _servicoRepository = servicoRepository;
        _customAuthenticationService = customAuthenticationService;
        _pagamentoRequestValidator = pagamentoRequestValidator;
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

    public ICollection<DiariaResponse> ListarPeloUsuarioLogado()
    {
        var usuario = _customAuthenticationService.GetUsuarioAutenticado();
        ICollection<Diaria> diarias;
        if (usuario.TipoUsuario == TipoUsuario.Diarista)
        {
            diarias = _diariaRepository.FindByDiaristaId(usuario.Id);
        }
        else
        {
            diarias = _diariaRepository.FindByClienteId(usuario.Id);
        }
        return diarias.Select(d => _diariaMapper.ToResponse(d)).ToList();
    }

    public MessageResponse Pagar(PagamentoRequest request, int diariaId)
    {
        var diaria = _diariaRepository.FindById(diariaId);
        if (diaria == null)
        {
            throw new DiariaNotFoundException();
        }
        request.DiariaStatus = diaria.Status;
        _pagamentoRequestValidator.ValidateAndThrow(request);

        diaria.Status = DiariaStatus.Pago;
        _diariaRepository.Update(diaria);

        return new MessageResponse
        {
            Message = "Pagamento realizado com sucesso"
        };
    }

    private decimal calcularComissao(Diaria diaria)
    {
        var servico = _servicoRepository.FindById(diaria.ServicoId);
        return diaria.Preco * (servico?.PorcentagemComissao / 100) ?? 0;
    }
}