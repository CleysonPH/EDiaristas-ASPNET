using EDiaristas.Api.Common.Dtos;
using EDiaristas.Api.Usuarios.Dtos;
using EDiaristas.Core.Models;

namespace EDiaristas.Api.Usuarios.Mappers;

public interface IUsuarioMapper
{
    Usuario ToModel(UsuarioRequest request);
    UsuarioResponse ToResponse(Usuario usuario);
    UsuarioCreatedResponse ToCreatedResponse(Usuario usuario);
}