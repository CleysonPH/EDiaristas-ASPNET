using EDiaristas.Api.Usuarios.Dtos;

namespace EDiaristas.Api.Usuarios.Services;

public interface IUsuarioService
{
    UsuarioCreatedResponse Cadastrar(UsuarioRequest request);
}