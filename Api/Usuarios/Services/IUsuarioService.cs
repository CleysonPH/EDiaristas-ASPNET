using EDiaristas.Api.Usuarios.Dtos;

namespace EDiaristas.Api.Usuarios.Services;

public interface IUsuarioService
{
    UsuarioResponse Cadastrar(UsuarioRequest request);
}