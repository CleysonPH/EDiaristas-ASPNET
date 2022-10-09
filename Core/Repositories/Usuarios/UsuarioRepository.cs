using EDiaristas.Core.Data.Contexts;
using EDiaristas.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EDiaristas.Core.Repositories.Usuarios;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly EDiaristasDbContext _context;

    public UsuarioRepository(EDiaristasDbContext context)
    {
        _context = context;
    }

    public Usuario Create(Usuario model)
    {
        _context.Usuarios.Add(model);
        _context.SaveChanges();
        return model;
    }

    public void DeleteById(int id)
    {
        var usuario = _context.Usuarios.Find(id);
        if (usuario != null)
        {
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
        }
    }

    public bool ExistsByCidadesAtendidasCodigoIbge(string codigoIbge)
    {
        return _context.Usuarios
            .AsNoTracking()
            .Include(x => x.CidadesAtendidas)
            .Any(x => x.CidadesAtendidas.Any(y => y.CodigoIbge == codigoIbge));
    }

    public bool ExistsByCpf(string cpf)
    {
        return _context.Usuarios
            .AsNoTracking()
            .Any(x => x.Cpf == cpf);
    }

    public bool ExistsByCpfAndNotId(string cpf, int id)
    {
        return _context.Usuarios
            .AsNoTracking()
            .Any(x => x.Cpf == cpf && x.Id != id);
    }

    public bool ExistsByEmail(string email)
    {
        return _context.Usuarios
            .AsNoTracking()
            .Any(x => x.Email == email);
    }

    public bool ExistsByEmailAndNotId(string email, int id)
    {
        return _context.Usuarios
            .AsNoTracking()
            .Any(x => x.Email == email && x.Id != id);
    }

    public bool ExistsById(int id)
    {
        return _context.Usuarios
            .AsNoTracking()
            .Any(x => x.Id == id);
    }

    public ICollection<Usuario> FindAll()
    {
        return _context.Usuarios.ToList();
    }

    public PagedResult<Usuario> FindByCidadesAtentidasCodigoIbge(string codigoIbge, PagedFilter filter)
    {
        var query = _context.Usuarios
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
        return _context.Usuarios
            .FirstOrDefault(x => x.Email == email);
    }

    public Usuario? FindById(int id)
    {
        return _context.Usuarios.FirstOrDefault(x => x.Id == id);
    }

    public ICollection<Usuario> FindByTipoUsuario(TipoUsuario tipoUsuario)
    {
        return _context.Usuarios
            .Where(x => x.TipoUsuario == tipoUsuario)
            .ToList();
    }

    public ICollection<Usuario> FindCandidatos(Diaria diaria)
    {
        return _context.Usuarios
            .Include(x => x.CidadesAtendidas)
            .Where(x =>
                x.TipoUsuario == TipoUsuario.Diarista &&
                x.CidadesAtendidas.Any(y => y.CodigoIbge == diaria.CodigoIbge))
            .ToList();
    }

    public double GetMediaReputacaoByTipoUsuario(TipoUsuario tipoUsuario)
    {
        var usuarios = _context.Usuarios
            .Where(x => x.TipoUsuario == tipoUsuario)
            .ToList();
        var total = usuarios.Count();
        var somaReputacao = usuarios.Sum(x => x.Reputacao) ?? 0.0;
        var mediaReputacao = somaReputacao / total;
        return double.IsNaN(mediaReputacao) ? 0.0 : mediaReputacao;
    }

    public Usuario Update(Usuario model)
    {
        _context.Usuarios.Update(model);
        _context.SaveChanges();
        return model;
    }
}