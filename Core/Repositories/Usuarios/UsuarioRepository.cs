using EDiaristas.Core.Data.Contexts;
using EDiaristas.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EDiaristas.Core.Repositories.Usuarios;

public class UsuarioRepository : AbstractRepository<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(EDiaristasDbContext context) : base(context)
    { }

    public bool ExistsByCidadesAtendidasCodigoIbge(string codigoIbge)
    {
        return context.Usuarios
            .AsNoTracking()
            .Include(x => x.CidadesAtendidas)
            .Any(x => x.CidadesAtendidas.Any(y => y.CodigoIbge == codigoIbge));
    }

    public bool ExistsByCpf(string cpf)
    {
        return context.Usuarios
            .AsNoTracking()
            .Any(x => x.Cpf == cpf);
    }

    public bool ExistsByCpfAndNotId(string cpf, int id)
    {
        return context.Usuarios
            .AsNoTracking()
            .Any(x => x.Cpf == cpf && x.Id != id);
    }

    public bool ExistsByEmail(string email)
    {
        return context.Usuarios
            .AsNoTracking()
            .Any(x => x.Email == email);
    }

    public bool ExistsByEmailAndNotId(string email, int id)
    {
        return context.Usuarios
            .AsNoTracking()
            .Any(x => x.Email == email && x.Id != id);
    }

    public PagedResult<Usuario> FindByCidadesAtentidasCodigoIbge(string codigoIbge, PagedFilter filter)
    {
        var query = context.Usuarios
            .Include(x => x.CidadesAtendidas)
            .Where(x => x.CidadesAtendidas.Any(y => y.CodigoIbge == codigoIbge));
        var totalElements = query.Count();
        var elements = query
            .Skip(filter.PageSize * (filter.Page - 1))
            .Take(filter.PageSize)
            .ToList();
        return new PagedResult<Usuario>
        {
            Elements = elements,
            TotalElements = totalElements,
            PageSize = filter.PageSize,
        };
    }

    public Usuario? FindByEmail(string email)
    {
        return context.Usuarios
            .FirstOrDefault(x => x.Email == email);
    }

    public ICollection<Usuario> FindByTipoUsuario(TipoUsuario tipoUsuario)
    {
        return context.Usuarios
            .Where(x => x.TipoUsuario == tipoUsuario)
            .ToList();
    }

    public ICollection<Usuario> FindCandidatos(Diaria diaria)
    {
        return context.Usuarios
            .Include(x => x.CidadesAtendidas)
            .Where(x =>
                x.TipoUsuario == TipoUsuario.Diarista &&
                x.CidadesAtendidas.Any(y => y.CodigoIbge == diaria.CodigoIbge))
            .ToList();
    }

    public double GetMediaReputacaoByTipoUsuario(TipoUsuario tipoUsuario)
    {
        var usuarios = context.Usuarios
            .Where(x => x.TipoUsuario == tipoUsuario)
            .ToList();
        var total = usuarios.Count();
        var somaReputacao = usuarios.Sum(x => x.Reputacao) ?? 0.0;
        var mediaReputacao = somaReputacao / total;
        return double.IsNaN(mediaReputacao) ? 0.0 : mediaReputacao;
    }
}