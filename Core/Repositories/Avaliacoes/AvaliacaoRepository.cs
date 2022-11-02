using EDiaristas.Core.Data.Contexts;
using EDiaristas.Core.Models;

namespace EDiaristas.Core.Repositories.Avaliacoes;

public class AvaliacaoRepository : AbstractRepository<Avaliacao>, IAvaliacaoRepository
{
    public AvaliacaoRepository(EDiaristasDbContext context) : base(context)
    { }

    public bool ExistsByAvaliadorIdAndDiariaId(int avaliadorId, int diariaId)
    {
        return context.Avaliacoes
            .Any(a => a.AvaliadorId == avaliadorId && a.DiariaId == diariaId);
    }

    public bool ExistsByDiariaAndAvaliador(Diaria diaria, Usuario avaliador)
    {
        return context.Avaliacoes.Any(a =>
            a.DiariaId == diaria.Id && a.AvaliadorId == avaliador.Id);
    }

    public ICollection<Avaliacao> FindByAvaliadoId(int avaliadoId, int take)
    {
        return context.Avaliacoes
            .Where(a => a.AvaliadoId == avaliadoId)
            .OrderByDescending(a => a.CreatedAt)
            .Take(take)
            .ToList();
    }

    public double GetAvaliacaoMedia(Usuario avaliado)
    {
        var avalicaoes = context.Avaliacoes.Where(a => a.AvaliadoId == avaliado.Id);
        var count = avalicaoes.Count();
        var total = avalicaoes.Sum(a => a.Nota);
        var media = total / count;
        return double.IsNaN(media) ? 0.0 : media;
    }
}