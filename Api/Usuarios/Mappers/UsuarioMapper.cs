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
}