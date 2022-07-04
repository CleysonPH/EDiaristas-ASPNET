using EDiaristas.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDiaristas.Core.Data.EntityConfigs;

public class ServicoEntityConfig : IEntityTypeConfiguration<Servico>
{
    public void Configure(EntityTypeBuilder<Servico> builder)
    {
        builder.ToTable("Servicos");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Nome)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(s => s.ValorMinimo)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(s => s.QtdHoras)
            .IsRequired();

        builder.Property(s => s.PorcentagemComissao)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(s => s.HorasQuarto)
            .IsRequired();

        builder.Property(s => s.ValorQuarto)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(s => s.HorasSala)
            .IsRequired();

        builder.Property(s => s.ValorSala)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(s => s.HorasBanheiro)
            .IsRequired();

        builder.Property(s => s.ValorBanheiro)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(s => s.HorasCozinha)
            .IsRequired();

        builder.Property(s => s.ValorCozinha)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(s => s.HorasQuintal)
            .IsRequired();

        builder.Property(s => s.ValorQuintal)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(s => s.HorasOutros)
            .IsRequired();

        builder.Property(s => s.ValorOutros)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(s => s.Icone)
            .IsRequired()
            .HasConversion<string>(
                v => v.ToName(),
                v => v.ToIcone()
            );

        builder.Property(s => s.Posicao)
            .IsRequired();
    }
}