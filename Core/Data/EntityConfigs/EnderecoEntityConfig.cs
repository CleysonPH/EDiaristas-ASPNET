using EDiaristas.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDiaristas.Core.Data.EntityConfigs;

public class EnderecoEntityConfig : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.ToTable("Enderecos");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Logradouro)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.Numero)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(e => e.Bairro)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.Complemento)
            .HasMaxLength(100)
            .IsRequired(false);

        builder.Property(e => e.Cidade)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.Estado)
            .HasMaxLength(2)
            .IsRequired();
    }
}