using EDiaristas.Api.Common.Dtos;

namespace EDiaristas.Api.Usuarios.Dtos;

public class UsuarioCreatedResponse : UsuarioResponse
{
    public TokenResponse Token { get; set; } = new TokenResponse();
}