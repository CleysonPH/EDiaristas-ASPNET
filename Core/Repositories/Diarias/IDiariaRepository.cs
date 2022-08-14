using EDiaristas.Core.Models;

namespace EDiaristas.Core.Repositories.Diarias;

public interface IDiariaRepository : ICrudRepository<Diaria, int>
{
    bool ExistsByIdAndClienteId(int diariaId, int clienteId);
    bool ExistsByIdAndDiaristaId(int diariaId, int diaristaId);
    ICollection<Diaria> FindByClienteId(int clienteId);
    ICollection<Diaria> FindByDiaristaId(int diaristaId);
    ICollection<Diaria> FindOportunidades(ICollection<string> cidades, Usuario candidato);
    ICollection<Diaria> FindAptasParaSelecao();
}