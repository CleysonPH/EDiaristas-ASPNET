using EDiaristas.Core.Data.Contexts;
using EDiaristas.Core.Models;

namespace EDiaristas.Core.Repositories.Pagamentos;

public class PagamentoRepository : IPagamentoRepository
{
    private readonly EDiaristasDbContext _context;

    public PagamentoRepository(EDiaristasDbContext context)
    {
        _context = context;
    }

    public Pagamento Create(Pagamento model)
    {
        _context.Pagamentos.Add(model);
        _context.SaveChanges();
        return model;
    }

    public void DeleteById(int id)
    {
        var pagamento = _context.Pagamentos.Find(id);
        if (pagamento is not null)
        {
            _context.Pagamentos.Remove(pagamento);
            _context.SaveChanges();
        }
    }

    public bool ExistsById(int id)
    {
        return _context.Pagamentos.Any(p => p.Id == id);
    }

    public ICollection<Pagamento> FindAll()
    {
        return _context.Pagamentos.ToList();
    }

    public Pagamento? FindById(int id)
    {
        return _context.Pagamentos.Find(id);
    }

    public Pagamento Update(Pagamento model)
    {
        _context.Pagamentos.Update(model);
        _context.SaveChanges();
        return model;
    }
}