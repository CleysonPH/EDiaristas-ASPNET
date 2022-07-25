using EDiaristas.Api.EnderecosDiarista.Dtos;
using EDiaristas.Api.EnderecosDiarista.Mappers;
using EDiaristas.Core.Exceptions;
using EDiaristas.Core.Repositories.Usuarios;
using EDiaristas.Core.Services.Authentication.Adapters;
using FluentValidation;

namespace EDiaristas.Api.EnderecosDiarista.Services;

public class EnderecoDiaristaService : IEnderecoDiaristaService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IEnderecoDiaristaMapper _enderecoDiaristaMapper;
    private readonly ICustomAuthenticationService _customAuthenticationService;
    private readonly IValidator<EnderecoDiaristaRequest> _enderecoDiaristaValidator;

    public EnderecoDiaristaService(
        IUsuarioRepository usuarioRepository,
        IEnderecoDiaristaMapper enderecoDiaristaMapper,
        ICustomAuthenticationService customAuthenticationService,
        IValidator<EnderecoDiaristaRequest> enderecoDiaristaValidator)
    {
        _usuarioRepository = usuarioRepository;
        _enderecoDiaristaMapper = enderecoDiaristaMapper;
        _customAuthenticationService = customAuthenticationService;
        _enderecoDiaristaValidator = enderecoDiaristaValidator;
    }

    public EnderecoDiaristaResponse AlterarEndereco(EnderecoDiaristaRequest request)
    {
        _enderecoDiaristaValidator.ValidateAndThrow(request);
        var usuario = _customAuthenticationService.GetUsuarioAutenticado();
        usuario.Endereco = _enderecoDiaristaMapper.ToModel(request);
        _usuarioRepository.Update(usuario);
        return _enderecoDiaristaMapper.ToResponse(usuario.Endereco);
    }

    public EnderecoDiaristaResponse ObterEnderecoUsuarioLogado()
    {
        var usuario = _customAuthenticationService.GetUsuarioAutenticado();
        if (usuario.Endereco == null)
        {
            throw new EnderecoDiaristaNotFoundException();
        }
        return _enderecoDiaristaMapper.ToResponse(usuario.Endereco);
    }
}