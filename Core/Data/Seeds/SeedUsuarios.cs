using EDiaristas.Core.Models;
using EDiaristas.Core.Repositories.Usuarios;
using EDiaristas.Core.Services.PasswordEnconder.Adapters;

namespace EDiaristas.Core.Data.Seeds;

public class SeedUsuarios : ISeedUsuarios
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IPasswordEnconderService _passwordEnconderService;

    public SeedUsuarios(IUsuarioRepository usuarioRepository, IPasswordEnconderService passwordEnconderService)
    {
        _usuarioRepository = usuarioRepository;
        _passwordEnconderService = passwordEnconderService;
    }

    public void Seed()
    {
        if (!_usuarioRepository.ExistsByEmail("admin@mail.com"))
        {
            var admin = new Usuario
            {
                Email = "admin@mail.com",
                NomeCompleto = "Usuário Administrador",
                TipoUsuario = TipoUsuario.Admin,
                Senha = _passwordEnconderService.Enconde("senha@123"),
            };
            _usuarioRepository.Create(admin);
        }
    }
}