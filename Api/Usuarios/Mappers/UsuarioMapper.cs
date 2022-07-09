using EDiaristas.Api.Usuarios.Dtos;
using EDiaristas.Core.Models;

namespace EDiaristas.Api.Usuarios.Mappers;

public class UsuarioMapper : IUsuarioMapper
{
    public Usuario ToModel(UsuarioRequest request)
    {
        return new Usuario
        {
            NomeCompleto = request.NomeCompleto,
            UserName = request.Email,
            Email = request.Email,
            PasswordHash = request.Password,
            Cpf = request.Cpf,
            Nascimento = request.Nascimento,
            PhoneNumber = request.Telefone,
            ChavePix = request.ChavePix,
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
            Telefone = usuario.PhoneNumber,
            ChavePix = usuario.ChavePix ?? string.Empty,
        };
    }
}