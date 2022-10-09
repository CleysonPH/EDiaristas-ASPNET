using System.Collections;
using EDiaristas.Api.Common.Dtos;
using EDiaristas.Api.Diarias.Dtos;
using EDiaristas.Api.Diarias.Mappers;
using EDiaristas.Core.Exceptions;
using EDiaristas.Core.Models;
using EDiaristas.Core.Repositories.Diarias;
using EDiaristas.Core.Repositories.Servicos;
using EDiaristas.Core.Repositories.Usuarios;
using EDiaristas.Core.Services.Authentication.Adapters;
using EDiaristas.Core.Services.Email;
using EDiaristas.Core.Services.GatewayPagamento;
using FluentValidation;

namespace EDiaristas.Api.Diarias.Services;

public class DiariaService : IDiariaService
{
    private readonly IDiariaMapper _diariaMapper;
    private readonly IEmailService _emailService;
    private readonly IDiariaRepository _diariaRepository;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IServicoRepository _servicoRepository;
    private readonly IValidator<DiariaRequest> _diariaRequestValidator;
    private readonly IGatewayPagamentoService _gatewayPagamentoService;
    private readonly IValidator<PagamentoRequest> _pagamentoRequestValidator;
    private readonly ICustomAuthenticationService _customAuthenticationService;

    public DiariaService(
        IDiariaMapper diariaMapper,
        IEmailService emailService,
        IDiariaRepository diariaRepository,
        IUsuarioRepository usuarioRepository,
        IServicoRepository servicoRepository,
        IGatewayPagamentoService gatewayPagamentoService,
        IValidator<DiariaRequest> diariaRequestValidator,
        IValidator<PagamentoRequest> pagamentoRequestValidator,
        ICustomAuthenticationService customAuthenticationService)
    {
        _diariaMapper = diariaMapper;
        _emailService = emailService;
        _diariaRepository = diariaRepository;
        _usuarioRepository = usuarioRepository;
        _servicoRepository = servicoRepository;
        _diariaRequestValidator = diariaRequestValidator;
        _gatewayPagamentoService = gatewayPagamentoService;
        _pagamentoRequestValidator = pagamentoRequestValidator;
        _customAuthenticationService = customAuthenticationService;
    }

    public DiariaResponse BuscarPeloId(int diariaId)
    {
        var diaria = _diariaRepository.FindById(diariaId);
        if (diaria == null)
        {
            throw new DiariaNotFoundException();
        }
        return _diariaMapper.ToResponse(diaria);
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

        var pagamento = _gatewayPagamentoService.Pagar(diaria, request.CardHash);
        if (pagamento.Status == PagamentoStatus.Aceito)
        {
            diaria.Status = DiariaStatus.Pago;
            _diariaRepository.Update(diaria);
            enviarEmailDeOportunidade(diaria);
            return new MessageResponse("Pagamento realizado com sucesso");
        }
        return new MessageResponse("Pagamento recusado");
    }

    private void enviarEmailDeOportunidade(Diaria diaria)
    {
        var candidatos = _usuarioRepository.FindCandidatos(diaria);
        candidatos.ToList().ForEach(candidato =>
        {
            var emailParams = new EmailParams(
                destinatario: candidato.Email,
                assunto: "Nova oportunidade",
                template: EmailParams.TemplateOptions.NovaOportunidade,
                props: new Dictionary<string, string>()
            );
            _emailService.EnviarAsync(emailParams);
        });
    }

    private decimal calcularComissao(Diaria diaria)
    {
        var servico = _servicoRepository.FindById(diaria.ServicoId);
        return diaria.Preco * (servico?.PorcentagemComissao / 100) ?? 0;
    }
}