using EDiaristas.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace EDiaristas.Core.Data.Seeds;

public class SeedUsuarios : ISeedUsuarios
{
    private readonly UserManager<Usuario> _userManager;

    public SeedUsuarios(UserManager<Usuario> userManager)
    {
        _userManager = userManager;
    }

    public void Seed()
    {
        if (_userManager.FindByNameAsync("admin@mail.com").Result == null)
        {
            var admin = new Usuario
            {
                UserName = "admin@mail.com",
                Email = "admin@mail.com",
                NomeCompleto = "Usuário ADMIN"
            };
            var result = _userManager.CreateAsync(admin, "senha@123").Result;
            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(admin, Roles.Admin).Wait();
            }
        }
    }
}