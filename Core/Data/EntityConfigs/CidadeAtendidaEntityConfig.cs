using EDiaristas.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDiaristas.Core.Data.EntityConfigs;

public class CidadeAtendidaEntityConfig : IEntityTypeConfiguration<CidadeAtendida>
{
    public void Configure(EntityTypeBuilder<CidadeAtendida> builder)
    {
        builder.ToTable("CidadeAtendida");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.CodigoIbge)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.Cidade)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(c => c.Estado)
            .HasMaxLength(2)
            .IsRequired();

        builder.HasMany(c => c.Usuarios)
            .WithMany(u => u.CidadesAtendidas);
    }
}