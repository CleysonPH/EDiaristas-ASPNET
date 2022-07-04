using EDiaristas.Admin.Usuarios.Dtos;

namespace EDiaristas.Admin.Usuarios.Services;

public interface IUsuarioService
{
    void Create(UsuarioCreateForm form);
    ICollection<UsuarioSummary> FindAll();
    UsuarioUpdateForm FindById(int id);
    void UpdateById(int id, UsuarioUpdateForm form);
    void DeleteById(int id);
    void UpdatePassword(string email, UpdatePasswordForm form);
}