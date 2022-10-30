using EDiaristas.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDiaristas.Core.Data.EntityConfigs;

public class CidadeAtendidaEntityConfig : BaseModelEntityConfig<CidadeAtendida>
{
    public override void Configure(EntityTypeBuilder<CidadeAtendida> builder)
    {
        base.Configure(builder);
        builder.ToTable("CidadeAtendida");

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