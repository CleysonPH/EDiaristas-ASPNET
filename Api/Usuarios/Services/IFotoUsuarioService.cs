using EDiaristas.Api.Common.Dtos;
using EDiaristas.Api.Usuarios.Dtos;

namespace EDiaristas.Api.Usuarios.Services;

public interface IFotoUsuarioService
{
    MessageResponse AtualizarFotoUsuario(AtualizarFotoRequest request);
}