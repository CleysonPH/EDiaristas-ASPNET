using EDiaristas.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDiaristas.Core.Data.EntityConfigs;

public class UsuarioEntityConfig : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.Property(u => u.NomeCompleto)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(u => u.Cpf)
            .HasMaxLength(11)
            .IsRequired(false);

        builder.Property(u => u.Nascimento)
            .IsRequired(false);

        builder.Property(u => u.Reputacao)
            .HasPrecision(2, 1)
            .IsRequired(false);

        builder.Property(u => u.ChavePix)
            .HasMaxLength(255)
            .IsRequired(false);
    }
}