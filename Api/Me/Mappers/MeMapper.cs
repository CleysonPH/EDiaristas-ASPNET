using EDiaristas.Api.Me.Dtos;
using EDiaristas.Core.Models;

namespace EDiaristas.Api.Me.Mappers;

public class MeMapper : IMeMapper
{
    public MeResponse ToResponse(Usuario usuario)
    {
        return new MeResponse
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