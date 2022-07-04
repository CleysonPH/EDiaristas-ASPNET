using EDiaristas.Admin.Usuarios.Dtos;
using EDiaristas.Core.Models;

namespace EDiaristas.Admin.Usuarios.Mappers;

public interface IUsuarioMapper
{
    Usuario ToModel(UsuarioCreateForm form);
    UsuarioSummary ToSummary(Usuario usuario);
    UsuarioUpdateForm ToUpdateForm(Usuario foundUsuario);
}