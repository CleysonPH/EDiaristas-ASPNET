using EDiaristas.Admin.Usuarios.Dtos;
using EDiaristas.Core.Models;

namespace EDiaristas.Admin.Usuarios.Mappers;

public class UsuarioMapper : IUsuarioMapper
{
    public Usuario ToModel(UsuarioCreateForm form)
    {
        return new Usuario
        {
            NomeCompleto = form.NomeCompleto,
            Email = form.Email,
            Senha = form.Senha
        };
    }

    public UsuarioSummary ToSummary(Usuario usuario)
    {
        return new UsuarioSummary
        {
            Id = usuario.Id,
            NomeCompleto = usuario.NomeCompleto,
            Email = usuario.Email
        };
    }

    public UsuarioUpdateForm ToUpdateForm(Usuario foundUsuario)
    {
        return new UsuarioUpdateForm
        {
            NomeCompleto = foundUsuario.NomeCompleto,
            Email = foundUsuario.Email
        };
    }
}