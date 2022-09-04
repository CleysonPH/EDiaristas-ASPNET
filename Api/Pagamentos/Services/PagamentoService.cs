using EDiaristas.Api.Pagamentos.Dtos;
using EDiaristas.Api.Pagamentos.Mappers;
using EDiaristas.Core.Models;
using EDiaristas.Core.Repositories.Pagamentos;
using EDiaristas.Core.Services.Authentication.Adapters;

namespace EDiaristas.Api.Pagamentos.Services;

public class PagamentoService : IPagamentoService
{
    private readonly IPagamentoMapper _pagamentoMapper;
    private readonly IPagamentoRepository _pagamentoRepository;
    private readonly ICustomAuthenticationService _authenticationService;

    public PagamentoService(
        IPagamentoMapper pagamentoMapper,
        IPagamentoRepository pagamentoRepository,
        ICustomAuthenticationService authenticationService)
    {
        _pagamentoMapper = pagamentoMapper;
        _pagamentoRepository = pagamentoRepository;
        _authenticationService = authenticationService;
    }

    public ICollection<PagamentoResponse> Listar()
    {
        var usuarioAutenticado = _authenticationService.GetUsuarioAutenticado();
        var statuses = new[]
        {
            DiariaStatus.Concluido,
            DiariaStatus.Avaliado,
            DiariaStatus.Transferido,
        };
        return _pagamentoRepository
            .FindByDiaristaAndDiariaStatuses(usuarioAutenticado.Id, statuses)
            .Select(_pagamentoMapper.ToResponse)
            .ToList();
    }
}