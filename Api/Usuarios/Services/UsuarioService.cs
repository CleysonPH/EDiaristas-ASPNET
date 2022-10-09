using EDiaristas.Api.Common.Dtos;
using EDiaristas.Api.Usuarios.Dtos;
using EDiaristas.Api.Usuarios.Mappers;
using EDiaristas.Core.Models;
using EDiaristas.Core.Repositories.Usuarios;
using EDiaristas.Core.Services.Authentication.Adapters;
using EDiaristas.Core.Services.Email;
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
    private readonly ICustomAuthenticationService _authenticationService;
    private readonly IValidator<AtualizarUsuarioRequest> _atualizarUsuarioValidator;
    private readonly IEmailService _emailService;

    private const double REPUTACAO_MAXIMA = 5.0;

    public UsuarioService(
        IUsuarioMapper usuarioMapper,
        IUsuarioRepository usuarioRepository,
        IValidator<UsuarioRequest> validator,
        IPasswordEnconderService passwordEnconderService,
        ITokenService tokenService,
        ICustomAuthenticationService authenticationService,
        IValidator<AtualizarUsuarioRequest> atualizarUsuarioValidator,
        IEmailService emailService)
    {
        _usuarioMapper = usuarioMapper;
        _usuarioRepository = usuarioRepository;
        _validator = validator;
        _passwordEnconderService = passwordEnconderService;
        _tokenService = tokenService;
        _authenticationService = authenticationService;
        _atualizarUsuarioValidator = atualizarUsuarioValidator;
        _emailService = emailService;
    }

    public UsuarioCreatedResponse Cadastrar(UsuarioRequest request)
    {
        _validator.ValidateAndThrow(request);
        var usuarioParaCadastrar = _usuarioMapper.ToModel(request);
        usuarioParaCadastrar.Senha = _passwordEnconderService.Enconde(request.Password);
        usuarioParaCadastrar.Reputacao = calcularMediaReputacao(usuarioParaCadastrar.TipoUsuario);
        var usuarioCadastrado = _usuarioRepository.Create(usuarioParaCadastrar);
        enviarEmailDeBoasVindas(usuarioCadastrado);
        var response = _usuarioMapper.ToCreatedResponse(usuarioCadastrado);
        response.Token = generateTokenResponse(usuarioCadastrado);
        return response;
    }

    private void enviarEmailDeBoasVindas(Usuario usuarioCadastrado)
    {
        var props = new EmailParams(
            destinatario: usuarioCadastrado.Email,
            assunto: "Cadastro realizado com sucesso",
            template: EmailParams.TemplateOptions.BoasVindas,
            props: new Dictionary<string, string>
            {
                { "NomeCompleto", usuarioCadastrado.NomeCompleto },
                { "TipoUsuario", usuarioCadastrado.TipoUsuario.ToString() }
            }
        );
        _emailService.EnviarAsync(props);
    }

    public MessageResponse Atualizar(AtualizarUsuarioRequest request)
    {
        var usuario = _authenticationService.GetUsuarioAutenticado();
        request.Id = usuario.Id;
        _atualizarUsuarioValidator.ValidateAndThrow(request);
        atualizarInformacoesUsuarioLogado(usuario, request);
        alterarSenhaUsuarioLogado(usuario, request);
        _usuarioRepository.Update(usuario);
        return new MessageResponse("Usuário atualizado com sucesso");
    }

    private void alterarSenhaUsuarioLogado(Usuario usuario, AtualizarUsuarioRequest request)
    {
        var temQueAtualizarSenha = !string.IsNullOrEmpty(request.Password)
            && !string.IsNullOrEmpty(request.NewPassword)
            && !string.IsNullOrEmpty(request.PasswordConfirmation);

        if (temQueAtualizarSenha)
        {
            var novaSenha = _passwordEnconderService.Enconde(request.NewPassword ?? string.Empty);
            usuario.Senha = novaSenha;
        }
    }

    private void atualizarInformacoesUsuarioLogado(Usuario usuario, AtualizarUsuarioRequest request)
    {
        usuario.NomeCompleto = request.NomeCompleto ?? usuario.NomeCompleto;
        usuario.Email = request.Email ?? usuario.Email;
        usuario.Cpf = request.Cpf ?? usuario.Cpf;
        usuario.Nascimento = request.Nascimento ?? usuario.Nascimento;
        usuario.Telefone = request.Telefone ?? usuario.Telefone;
        usuario.ChavePix = request.ChavePix ?? usuario.ChavePix;
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