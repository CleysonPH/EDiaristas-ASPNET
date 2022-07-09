using EDiaristas.Api.Usuarios.Dtos;
using EDiaristas.Api.Usuarios.Mappers;
using EDiaristas.Core.Repositories.Usuarios;
using FluentValidation;

namespace EDiaristas.Api.Usuarios.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioMapper _usuarioMapper;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IValidator<UsuarioRequest> _validator;

    public UsuarioService(
        IUsuarioMapper usuarioMapper,
        IUsuarioRepository usuarioRepository,
        IValidator<UsuarioRequest> validator)
    {
        _usuarioMapper = usuarioMapper;
        _usuarioRepository = usuarioRepository;
        _validator = validator;
    }

    public UsuarioResponse Cadastrar(UsuarioRequest request)
    {
        _validator.ValidateAndThrow(request);
        var usuarioParaCadastrar = _usuarioMapper.ToModel(request);
        var usuarioCadastrado = _usuarioRepository.Create(usuarioParaCadastrar);
        return _usuarioMapper.ToResponse(usuarioCadastrado);
    }
}