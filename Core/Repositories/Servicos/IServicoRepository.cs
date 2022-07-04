using EDiaristas.Core.Models;

namespace EDiaristas.Core.Repositories.Servicos;

public interface IServicoRepository : ICrudRepository<Servico, int>
{
    ICollection<Servico> FindAll<TKey>(Func<Servico, TKey> keySelector);
}