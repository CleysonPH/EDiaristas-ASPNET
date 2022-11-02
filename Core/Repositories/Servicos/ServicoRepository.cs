using EDiaristas.Core.Data.Contexts;
using EDiaristas.Core.Models;

namespace EDiaristas.Core.Repositories.Servicos;

public class ServicoRepository : AbstractRepository<Servico>, IServicoRepository
{
    public ServicoRepository(EDiaristasDbContext context) : base(context)
    { }
}