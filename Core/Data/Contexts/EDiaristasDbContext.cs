using EDiaristas.Core.Data.EntityConfigs;
using EDiaristas.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EDiaristas.Core.Data.Contexts;

public class EDiaristasDbContext : DbContext
{
    public DbSet<Servico> Servicos => Set<Servico>();
    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<CidadeAtendida> CidadesAtendidas => Set<CidadeAtendida>();
    public DbSet<InvalidatedToken> InvalidatedTokens => Set<InvalidatedToken>();
    public DbSet<Diaria> Diarias => Set<Diaria>();

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
        builder.ApplyConfiguration(new ServicoEntityConfig());
        builder.ApplyConfiguration(new UsuarioEntityConfig());
        builder.ApplyConfiguration(new CidadeAtendidaEntityConfig());
        builder.ApplyConfiguration(new InvalidatedTokenEntityConfig());
        builder.ApplyConfiguration(new DiariaEntityConfig());
        builder.ApplyConfiguration(new EnderecoEntityConfig());
    }
}