using EDiaristas.Core.Data.Contexts;
using EDiaristas.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EDiaristas.Core.Repositories.Pagamentos;

public class PagamentoRepository : AbstractRepository<Pagamento>, IPagamentoRepository
{
    public PagamentoRepository(EDiaristasDbContext context) : base(context)
    { }

    public ICollection<Pagamento> FindByDiaristaAndDiariaStatuses(int diaristaId, ICollection<DiariaStatus> statuses)
    {
        return context.Pagamentos
            .Include(p => p.Diaria)
            .Where(p => p.Diaria.DiaristaId == diaristaId && statuses.Contains(p.Diaria.Status))
            .ToList();
    }
}