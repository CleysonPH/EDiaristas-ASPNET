using EDiaristas.Api.Common.Dtos;
using EDiaristas.Api.Usuarios.Dtos;
using EDiaristas.Core.Models;

namespace EDiaristas.Api.Usuarios.Mappers;

public class UsuarioMapper : IUsuarioMapper
{
    public UsuarioCreatedResponse ToCreatedResponse(Usuario usuario)
    {
        return new UsuarioCreatedResponse
        {
            Id = usuario.Id,
            NomeCompleto = usuario.NomeCompleto,
            Email = usuario.Email,
            Cpf = usuario.Cpf ?? string.Empty,
            Nascimento = usuario.Nascimento ?? DateTime.MinValue,
            Telefone = usuario.Telefone ?? string.Empty,
            ChavePix = usuario.ChavePix ?? string.Empty,
            TipoUsuario = usuario.TipoUsuario.ToTipoUsuarioInt(),
            FotoUsuario = usuario.FotoUsuario
        };
    }

    public Usuario ToModel(UsuarioRequest request)
    {
        return new Usuario
        {
            NomeCompleto = request.NomeCompleto,
            Email = request.Email,
            Senha = request.Password,
            Cpf = request.Cpf,
            Nascimento = request.Nascimento,
            Telefone = request.Telefone,
            ChavePix = request.ChavePix,
            TipoUsuario = request.TipoUsuario.ToTipoUsuario()
        };
    }

    public UsuarioResponse ToResponse(Usuario usuario)
    {
        return new UsuarioResponse
        {
            Id = usuario.Id,
            NomeCompleto = usuario.NomeCompleto,
            Email = usuario.Email,
            Cpf = usuario.Cpf ?? string.Empty,
            Nascimento = usuario.Nascimento ?? DateTime.MinValue,
            Telefone = usuario.Telefone ?? string.Empty,
            ChavePix = usuario.ChavePix ?? string.Empty,
            TipoUsuario = usuario.TipoUsuario.ToTipoUsuarioInt(),
            FotoUsuario = usuario.FotoUsuario
        };
    }
}