using EDiaristas.Core.Exceptions;
using EDiaristas.Core.Models;
using EDiaristas.Core.Repositories.PasswordRestToken;
using EDiaristas.Core.Repositories.Usuarios;
using EDiaristas.Core.Services.PasswordEnconder.Adapters;
using EDiaristas.Core.Services.PasswordReset.Adapters;

namespace EDiaristas.Core.Services.PasswordReset.Providers;

public class PasswordResetService : IPasswordResetService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IPasswordEnconderService _passwordEnconderService;
    private readonly IPasswordResetTokenRepository _passwordResetTokenRepository;

    public PasswordResetService(
        IUsuarioRepository usuarioRepository,
        IPasswordEnconderService passwordEnconderService,
        IPasswordResetTokenRepository passwordResetTokenRepository)
    {
        _usuarioRepository = usuarioRepository;
        _passwordEnconderService = passwordEnconderService;
        _passwordResetTokenRepository = passwordResetTokenRepository;
    }

    public string CriarPasswordResetToken(string email)
    {
        if (!_usuarioRepository.ExistsByEmail(email))
        {
            throw new UsuarioNotFoundException();
        }
        var passwordResetToken = new PasswordResetToken
        {
            Email = email,
            Token = Guid.NewGuid().ToString(),
            IssuedAt = DateTime.Now,
            ExpirationDate = DateTime.Now.AddMinutes(1)
        };
        _passwordResetTokenRepository.Create(passwordResetToken);
        return passwordResetToken.Token;
    }

    public void ResetarSenha(string token, string senha)
    {
        var passwordResetToken = _passwordResetTokenRepository.BuscarPorToken(token);
        if (passwordResetToken is null)
        {
            throw new PasswordResetTokenNotFoundException();
        }
        if (passwordResetToken.ExpirationDate < DateTime.Now)
        {
            throw new PasswordResetTokenExpiredException();
        }
        var usuario = _usuarioRepository.FindByEmail(passwordResetToken.Email);
        if (usuario is null)
        {
            throw new UsuarioNotFoundException();
        }
        usuario.Senha = _passwordEnconderService.Enconde(senha);
        _usuarioRepository.Update(usuario);
        _passwordResetTokenRepository.DeleteById(passwordResetToken.Id);
    }
}