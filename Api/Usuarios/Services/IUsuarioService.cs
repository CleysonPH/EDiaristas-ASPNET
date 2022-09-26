using EDiaristas.Api.Common.Dtos;
using EDiaristas.Api.Usuarios.Dtos;

namespace EDiaristas.Api.Usuarios.Services;

public interface IUsuarioService
{
    UsuarioCreatedResponse Cadastrar(UsuarioRequest request);
    MessageResponse Atualizar(AtualizarUsuarioRequest request);
}