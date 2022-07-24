using EDiaristas.Core.Models;

namespace EDiaristas.Core.Repositories.Diarias;

public interface IDiariaRepository : ICrudRepository<Diaria, int>
{
    bool ExistsByIdAndClienteId(int diariaId, int clienteId);
    ICollection<Diaria> FindByClienteId(int clienteId);
    ICollection<Diaria> FindByDiaristaId(int diaristaId);
}