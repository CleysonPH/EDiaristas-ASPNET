using EDiaristas.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace EDiaristas.Core.Data.Seeds;

public class SeedRoles : ISeedRoles
{
    private readonly RoleManager<IdentityRole<int>> _roleManager;

    public SeedRoles(RoleManager<IdentityRole<int>> roleManager)
    {
        _roleManager = roleManager;
    }

    public void Seed()
    {
        if (!_roleManager.RoleExistsAsync(Roles.Admin).Result)
        {
            _roleManager.CreateAsync(new IdentityRole<int>(Roles.Admin)).Wait();
        }

        if (!_roleManager.RoleExistsAsync(Roles.Cliente).Result)
        {
            _roleManager.CreateAsync(new IdentityRole<int>(Roles.Cliente)).Wait();
        }

        if (!_roleManager.RoleExistsAsync(Roles.Diarista).Result)
        {
            _roleManager.CreateAsync(new IdentityRole<int>(Roles.Diarista)).Wait();
        }
    }
}