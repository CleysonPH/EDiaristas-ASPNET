using EDiaristas.Api.Common.Dtos;
using EDiaristas.Api.Usuarios.Dtos;
using EDiaristas.Api.Usuarios.Mappers;
using EDiaristas.Core.Models;
using EDiaristas.Core.Repositories.Usuarios;
using EDiaristas.Core.Services.PasswordEnconder.Adapters;
using EDiaristas.Core.Services.Token.Adapters;
using FluentValidation;

namespace EDiaristas.Api.Usuarios.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioMapper _usuarioMapper;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IValidator<UsuarioRequest> _validator;
    private readonly IPasswordEnconderService _passwordEnconderService;
    private readonly ITokenService _tokenService;

    private const double REPUTACAO_MAXIMA = 5.0;

    public UsuarioService(
        IUsuarioMapper usuarioMapper,
        IUsuarioRepository usuarioRepository,
        IValidator<UsuarioRequest> validator,
        IPasswordEnconderService passwordEnconderService,
        ITokenService tokenService)
    {
        _usuarioMapper = usuarioMapper;
        _usuarioRepository = usuarioRepository;
        _validator = validator;
        _passwordEnconderService = passwordEnconderService;
        _tokenService = tokenService;
    }

    public UsuarioCreatedResponse Cadastrar(UsuarioRequest request)
    {
        _validator.ValidateAndThrow(request);
        var usuarioParaCadastrar = _usuarioMapper.ToModel(request);
        usuarioParaCadastrar.Senha = _passwordEnconderService.Enconde(request.Password);
        usuarioParaCadastrar.Reputacao = calcularMediaReputacao(usuarioParaCadastrar.TipoUsuario);
        var usuarioCadastrado = _usuarioRepository.Create(usuarioParaCadastrar);
        var response = _usuarioMapper.ToCreatedResponse(usuarioCadastrado);
        response.Token = generateTokenResponse(usuarioCadastrado);
        return response;
    }

    private TokenResponse generateTokenResponse(Usuario usuario)
    {
        return new TokenResponse
        {
            Access = _tokenService.GenerateAccessToken(usuario),
            Refresh = _tokenService.GenerateRefreshToken(usuario)
        };
    }

    private double calcularMediaReputacao(TipoUsuario tipoUsuario)
    {
        var mediaReputacao = _usuarioRepository.GetMediaReputacaoByTipoUsuario(tipoUsuario);
        return mediaReputacao == 0.0 ? REPUTACAO_MAXIMA : mediaReputacao;
    }
}