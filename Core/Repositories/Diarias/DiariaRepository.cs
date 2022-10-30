using EDiaristas.Core.Data.Contexts;
using EDiaristas.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EDiaristas.Core.Repositories.Diarias;

public class DiariaRepository : AbstractRepository<Diaria>, IDiariaRepository
{
    public DiariaRepository(EDiaristasDbContext context) : base(context)
    { }

    public bool ExistsByIdAndClienteId(int diariaId, int clienteId)
    {
        return context.Diarias
            .Any(d => d.Id == diariaId && d.ClienteId == clienteId);
    }

    public bool ExistsByIdAndDiaristaId(int diariaId, int diaristaId)
    {
        return context.Diarias
            .Any(d => d.Id == diariaId && d.DiaristaId == diaristaId);
    }

    public ICollection<Diaria> FindAll<TKey>(Func<Diaria, TKey> keySelector, DiariaFiltro filtro, bool ascending = true)
    {
        var query = context.Diarias.AsQueryable();
        if (!string.IsNullOrEmpty(filtro.ClienteNome))
        {
            query = query.Include(d => d.Cliente)
                .Where(d => d.Cliente.NomeCompleto.Contains(filtro.ClienteNome));
        }
        if (filtro.Statuses.Count > 0)
        {
            query = query.Where(d => filtro.Statuses.Contains(d.Status));
        }
        if (ascending)
        {
            return query.OrderBy(keySelector).ToList();
        }
        return query.OrderByDescending(keySelector).ToList();
    }

    public ICollection<Diaria> FindAptasParaCancelamento()
    {
        return context.Diarias.Where(d =>
            (
                d.Status == DiariaStatus.Pago &&
                d.DataAtendimento < DateTime.Now.AddHours(24) &&
                d.Candidatos.Count == 0
            ) ||
            (
                d.Status == DiariaStatus.SemPagamento &&
                (d.CreatedAt == null || d.CreatedAt <= DateTime.Now.AddHours(-24)) &&
                d.Candidatos.Count == 0
            )
        ).ToList();
    }

    public ICollection<Diaria> FindAptasParaSelecao()
    {
        return context.Diarias.Where(d =>
            (
                d.Status == DiariaStatus.Pago &&
                d.Diarista == null &&
                d.Candidatos.Count() == 3
            ) ||
            (
                d.Status == DiariaStatus.Pago &&
                d.Diarista == null &&
                d.CreatedAt <= DateTime.Now.AddHours(-24) &&
                (d.Candidatos.Count() > 0 && d.Candidatos.Count() < 3)
            )
        ).ToList();
    }

    public ICollection<Diaria> FindByClienteId(int clienteId)
    {
        return context.Diarias
            .Where(d => d.ClienteId == clienteId)
            .ToList();
    }

    public ICollection<Diaria> FindByDiaristaId(int diaristaId)
    {
        return context.Diarias
            .Where(d => d.DiaristaId == diaristaId)
            .ToList();
    }

    public ICollection<Diaria> FindOportunidades(ICollection<string> cidades, Usuario candidato)
    {
        return context.Diarias
            .Include(d => d.Candidatos)
            .Where(d =>
                d.Status == DiariaStatus.Pago &&
                cidades.Any(c => c == d.CodigoIbge) &&
                d.DiaristaId == null &&
                d.Candidatos.Count() < 3 &&
                !d.Candidatos.Any(c => c.Id == candidato.Id)
            )
            .ToList();
    }

    public bool IsAvaliada(int diariaId)
    {
        return context.Diarias
            .Include(d => d.Avaliacoes)
            .Where(d => d.Id == diariaId && d.Avaliacoes.Count() >= 2)
            .Any();
    }
}