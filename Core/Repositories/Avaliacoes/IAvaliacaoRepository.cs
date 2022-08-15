using EDiaristas.Core.Models;

namespace EDiaristas.Core.Repositories.Avaliacoes;

public interface IAvaliacaoRepository : ICrudRepository<Avaliacao, int>
{
    bool ExistsByDiariaAndAvaliador(Diaria diaria, Usuario avaliador);
    double GetAvaliacaoMedia(Usuario avaliado);
    bool ExistsByAvaliadorIdAndDiariaId(int avaliadorId, int diariaId);
    ICollection<Avaliacao> FindByAvaliadoId(int avaliadoId, int take);
}