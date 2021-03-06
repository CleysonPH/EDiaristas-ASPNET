using EDiaristas.Core.Models;

namespace EDiaristas.Core.Repositories.Usuarios;

public interface IUsuarioRepository : ICrudRepository<Usuario, int>
{
    bool ExistsByEmail(string email);
    bool ExistsByCpf(string cpf);
    bool ExistsByCpfAndNotId(string cpf, int id);
    bool ExistsByEmailAndNotId(string email, int id);
    Usuario? FindByEmail(string email);
    PagedResult<Usuario> FindByCidadesAtentidasCodigoIbge(string codigoIbge, PagedFilter filter);
    bool ExistsByCidadesAtendidasCodigoIbge(string codigoIbge);
    double GetMediaReputacaoByTipoUsuario(TipoUsuario tipoUsuario);
    ICollection<Usuario> FindByTipoUsuario(TipoUsuario tipoUsuario);
}