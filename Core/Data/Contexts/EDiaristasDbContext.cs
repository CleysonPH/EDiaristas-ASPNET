using EDiaristas.Core.Data.EntityConfigs;
using EDiaristas.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EDiaristas.Core.Data.Contexts;

public class EDiaristasDbContext : IdentityDbContext<Usuario, IdentityRole<int>, int>
{
    public DbSet<Servico> Servicos => Set<Servico>();

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer("Server=Localhost;Database=EDiaristas;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ServicoEntityConfig());
        builder.ApplyConfiguration(new UsuarioEntityConfig());
        builder.ApplyConfiguration(new CidadeAtendidaEntityConfig());
    }
}