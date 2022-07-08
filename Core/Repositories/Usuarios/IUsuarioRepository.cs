using EDiaristas.Core.Models;

namespace EDiaristas.Core.Repositories.Usuarios;

public interface IUsuarioRepository : ICrudRepository<Usuario, int>
{
    bool ExistsByEmail(string email);
    bool ExistsByEmailAndNotId(string email, int id);
    Usuario? FindByEmail(string email);
    void UpdatePassword(string email, string oldPassword, string newPassword);
    bool CheckPassword(string email, string password);
    void AddRole(string email, string role);
    PagedResult<Usuario> FindByCidadesAtentidasCodigoIbge(string codigoIbge, PagedFilter filter);
}