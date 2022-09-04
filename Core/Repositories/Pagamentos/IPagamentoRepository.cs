using EDiaristas.Core.Models;

namespace EDiaristas.Core.Repositories.Pagamentos;

public interface IPagamentoRepository : ICrudRepository<Pagamento, int>
{
    ICollection<Pagamento> FindByDiaristaAndDiariaStatuses(int diaristaId, ICollection<DiariaStatus> statuses);
}