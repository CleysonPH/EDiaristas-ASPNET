using EDiaristas.Core.Data.EntityConfigs;
using EDiaristas.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EDiaristas.Core.Data.Contexts;

public class EDiaristasDbContext : IdentityDbContext<Usuario, IdentityRole<int>, int>
{
    public DbSet<Servico> Servicos => Set<Servico>();

    private readonly string _connectionString;

    public EDiaristasDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        _connectionString = configuration.GetConnectionString("EDiaristasSqlServer");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ServicoEntityConfig());
        builder.ApplyConfiguration(new UsuarioEntityConfig());
        builder.ApplyConfiguration(new CidadeAtendidaEntityConfig());
    }
}