using EDiaristas.Api.CidadesAtentidas.Dtos;
using EDiaristas.Api.CidadesAtentidas.Mappers;
using EDiaristas.Api.Common.Dtos;
using EDiaristas.Core.Models;
using EDiaristas.Core.Repositories.CidadesAtendidas;
using EDiaristas.Core.Repositories.Usuarios;
using EDiaristas.Core.Services.Authentication.Adapters;
using EDiaristas.Core.Services.ConsultaCidade.Adapters;
using FluentValidation;

namespace EDiaristas.Api.CidadesAtentidas.Services;

public class CidadeAtendidaService : ICidadeAtendidaService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly ICidadeAtendidaMapper _cidadeAtendidaMapper;
    private readonly IConsultaCidadeService _consultaCidadeService;
    private readonly ICustomAuthenticationService _authenticationService;
    private readonly ICidadeAtendidaRepository _cidadeAtendidaRepository;
    private readonly IValidator<CidadesAtendidasRequest> _cidadesAtendidasRequestValidator;

    public CidadeAtendidaService(
        ICidadeAtendidaMapper cidadeAtendidaMapper,
        ICustomAuthenticationService authenticationService,
        IValidator<CidadesAtendidasRequest> cidadesAtendidasRequestValidator,
        ICidadeAtendidaRepository cidadeAtendidaRepository,
        IConsultaCidadeService consultaCidadeService,
        IUsuarioRepository usuarioRepository)
    {
        _cidadeAtendidaMapper = cidadeAtendidaMapper;
        _authenticationService = authenticationService;
        _cidadesAtendidasRequestValidator = cidadesAtendidasRequestValidator;
        _cidadeAtendidaRepository = cidadeAtendidaRepository;
        _consultaCidadeService = consultaCidadeService;
        _usuarioRepository = usuarioRepository;
    }

    public MessageResponse Atualizar(CidadesAtendidasRequest request)
    {
        _cidadesAtendidasRequestValidator.ValidateAndThrow(request);
        var cidadesAtendidas = new List<CidadeAtendida>();
        request.Cidades.ToList().ForEach(c =>
        {
            var cidadeAtendia = _cidadeAtendidaRepository.FindByCodigoIbge(c.CodigoIbge);
            if (cidadeAtendia is null)
            {
                cidadeAtendia = cadastrarCidadeAtendida(c.CodigoIbge);
            }
            cidadesAtendidas.Add(cidadeAtendia);
        });
        var usuarioLogado = _authenticationService.GetUsuarioAutenticado();
        usuarioLogado.CidadesAtendidas.Clear();
        usuarioLogado.CidadesAtendidas = cidadesAtendidas;
        _usuarioRepository.Update(usuarioLogado);
        return new MessageResponse
        {
            Message = "Cidades atendidas atualizadas com sucesso!"
        };
    }

    public ICollection<CidadeAtendidaResponse> ListarPorUsuarioLogado()
    {
        var usuarioLogado = _authenticationService.GetUsuarioAutenticado();
        return usuarioLogado.CidadesAtendidas
            .Select(_cidadeAtendidaMapper.ToResponse)
            .ToList();
    }

    private CidadeAtendida cadastrarCidadeAtendida(string codigoIbge)
    {
        var cidade = _consultaCidadeService.BuscarCidadePorCodigoIbge(codigoIbge);
        var cidadeAtendida = new CidadeAtendida
        {
            CodigoIbge = cidade.Ibge,
            Cidade = cidade.Cidade,
            Estado = cidade.Estado
        };
        return _cidadeAtendidaRepository.Create(cidadeAtendida);
    }
}