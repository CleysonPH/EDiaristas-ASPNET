using EDiaristas.Core.Exceptions;
using EDiaristas.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EDiaristas.Core.Repositories.Usuarios;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly UserManager<Usuario> _userManager;

    public UsuarioRepository(UserManager<Usuario> userManager)
    {
        _userManager = userManager;
    }

    public void AddRole(string email, string role)
    {
        var user = _userManager.FindByEmailAsync(email).Result;
        if (user is not null)
        {
            _userManager.AddToRoleAsync(user, role).Wait();
        }
    }

    public bool CheckPassword(string email, string password)
    {
        var user = _userManager.FindByEmailAsync(email).Result;
        if (user is null)
        {
            return false;
        }
        return _userManager.CheckPasswordAsync(user, password).GetAwaiter().GetResult();
    }

    public Usuario Create(Usuario model)
    {
        var result = _userManager.CreateAsync(model, model.PasswordHash)
            .GetAwaiter()
            .GetResult();
        if (!result.Succeeded)
        {
            throw new UsuarioInsertionException(
                string.Join("; ", result.Errors.Select(e => e.Description))
            );
        }
        return model;
    }

    public void DeleteById(int id)
    {
        var usuario = _userManager.Users.FirstOrDefault(u => u.Id == id);
        if (usuario is not null)
        {
            _userManager.DeleteAsync(usuario).GetAwaiter().GetResult();
        }
    }

    public bool ExistsByEmail(string email)
    {
        return _userManager.Users.Any(u => u.Email == email);
    }

    public bool ExistsByEmailAndNotId(string email, int id)
    {
        return _userManager.Users.AsNoTracking().Any(u => u.Email == email && u.Id != id);
    }

    public bool ExistsById(int id)
    {
        return _userManager.Users.AsNoTracking().Any(u => u.Id == id);
    }

    public ICollection<Usuario> FindAll()
    {
        return _userManager.Users.AsNoTracking().ToList();
    }

    public PagedResult<Usuario> FindByCidadesAtentidasCodigoIbge(string codigoIbge, PagedFilter filter)
    {
        var query = _userManager.Users.AsNoTracking()
            .Include(x => x.CidadesAtendidas)
            .Where(x => x.CidadesAtendidas.Any(c => c.CodigoIbge == codigoIbge));
        var usuarios = query.Skip((filter.Page - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .OrderBy(x => x.Reputacao)
            .ToList();
        var count = query.Count();
        return new PagedResult<Usuario>
        {
            Elements = usuarios,
            PageSize = filter.PageSize,
            TotalElements = count
        };
    }

    public Usuario? FindByEmail(string email)
    {
        return _userManager.Users.AsNoTracking().FirstOrDefault(u => u.Email == email);
    }

    public Usuario? FindById(int id)
    {
        return _userManager.Users.AsNoTracking().FirstOrDefault(u => u.Id == id);
    }

    public Usuario Update(Usuario model)
    {
        var result = _userManager.UpdateAsync(model).GetAwaiter().GetResult();
        if (!result.Succeeded)
        {
            throw new UsuarioInsertionException(
                string.Join("; ", result.Errors.Select(e => e.Description))
            );
        }
        return model;
    }

    public void UpdatePassword(string email, string oldPassword, string newPassword)
    {
        var usuario = _userManager.Users.FirstOrDefault(u => u.Email == email);
        if (usuario is not null)
        {
            var result = _userManager.ChangePasswordAsync(usuario, oldPassword, newPassword).GetAwaiter().GetResult();
            if (!result.Succeeded)
            {
                throw new UsuarioInsertionException(
                    string.Join("; ", result.Errors.Select(e => e.Description))
                );
            }
        }
    }
}