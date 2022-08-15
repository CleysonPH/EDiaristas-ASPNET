using EDiaristas.Core.Data.Contexts;
using EDiaristas.Core.Models;

namespace EDiaristas.Core.Repositories.Avaliacoes;

public class AvaliacaoRepository : IAvaliacaoRepository
{
    private readonly EDiaristasDbContext _context;

    public AvaliacaoRepository(EDiaristasDbContext context)
    {
        _context = context;
    }

    public Avaliacao Create(Avaliacao model)
    {
        _context.Avaliacoes.Add(model);
        _context.SaveChanges();
        return model;
    }

    public void DeleteById(int id)
    {
        var avaliacao = _context.Avaliacoes.Find(id);
        if (avaliacao is not null)
        {
            _context.Avaliacoes.Remove(avaliacao);
            _context.SaveChanges();
        }
    }

    public bool ExistsByAvaliadorIdAndDiariaId(int avaliadorId, int diariaId)
    {
        return _context.Avaliacoes
            .Any(a => a.AvaliadorId == avaliadorId && a.DiariaId == diariaId);
    }

    public bool ExistsByDiariaAndAvaliador(Diaria diaria, Usuario avaliador)
    {
        return _context.Avaliacoes.Any(a =>
            a.DiariaId == diaria.Id && a.AvaliadorId == avaliador.Id);
    }

    public bool ExistsById(int id)
    {
        return _context.Avaliacoes.Any(a => a.Id == id);
    }

    public ICollection<Avaliacao> FindAll()
    {
        return _context.Avaliacoes.ToList();
    }

    public ICollection<Avaliacao> FindByAvaliadoId(int avaliadoId, int take)
    {
        return _context.Avaliacoes
            .Where(a => a.AvaliadoId == avaliadoId)
            .OrderByDescending(a => a.CreatedAt)
            .Take(take)
            .ToList();
    }

    public Avaliacao? FindById(int id)
    {
        return _context.Avaliacoes.Find(id);
    }

    public double GetAvaliacaoMedia(Usuario avaliado)
    {
        var avalicaoes = _context.Avaliacoes.Where(a => a.AvaliadoId == avaliado.Id);
        var count = avalicaoes.Count();
        var total = avalicaoes.Sum(a => a.Nota);
        var media = total / count;
        return double.IsNaN(media) ? 0.0 : media;
    }

    public Avaliacao Update(Avaliacao model)
    {
        _context.Avaliacoes.Update(model);
        _context.SaveChanges();
        return model;
    }
}