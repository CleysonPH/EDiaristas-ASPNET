using EDiaristas.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDiaristas.Core.Data.EntityConfigs;

public class DiariaEntityConfig : IEntityTypeConfiguration<Diaria>
{
    public void Configure(EntityTypeBuilder<Diaria> builder)
    {
        builder.ToTable("Diarias");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.DataAtendimento)
            .IsRequired();

        builder.Property(d => d.TempoAtendimento)
            .IsRequired();

        builder.Property(d => d.Status)
            .IsRequired()
            .HasMaxLength(12)
            .HasConversion(
                v => v.ToDiariaStatusName(),
                v => v.ToDiariaStatus()
            );

        builder.Property(d => d.Preco)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(d => d.ValorComissao)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(d => d.Logradouro)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(d => d.Numero)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(d => d.Bairro)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(d => d.Complemento)
            .HasMaxLength(100)
            .IsRequired(false);

        builder.Property(d => d.Cidade)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(d => d.Estado)
            .HasMaxLength(2)
            .IsRequired();

        builder.Property(d => d.Cep)
            .HasMaxLength(8)
            .IsRequired();

        builder.Property(d => d.CodigoIbge)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(d => d.QuantidadeQuartos)
            .IsRequired();

        builder.Property(d => d.QuantidadeSalas)
            .IsRequired();

        builder.Property(d => d.QuantidadeCozinhas)
            .IsRequired();

        builder.Property(d => d.QuantidadeBanheiros)
            .IsRequired();

        builder.Property(d => d.QuantidadeQuintais)
            .IsRequired();

        builder.Property(d => d.QuantidadeOutros)
            .IsRequired();

        builder.Property(d => d.Observacoes)
            .HasMaxLength(255)
            .IsRequired(false);

        builder.Property(d => d.MotivoCancelamento)
            .HasMaxLength(255)
            .IsRequired(false);

        builder.HasOne(d => d.Cliente)
            .WithMany()
            .HasForeignKey(d => d.ClienteId)
            .IsRequired();

        builder.HasOne(d => d.Cliente)
            .WithMany()
            .HasForeignKey(d => d.ClienteId)
            .IsRequired();

        builder.HasOne(d => d.Diarista)
            .WithMany()
            .HasForeignKey(d => d.DiaristaId)
            .IsRequired(false);

        builder.HasMany(d => d.Candidatos)
            .WithMany(u => u.Candidaturas)
            .UsingEntity<Dictionary<string, object>>(
                "Candidaturas",
                j => j
                    .HasOne<Usuario>()
                    .WithMany()
                    .OnDelete(DeleteBehavior.NoAction),
                j => j
                    .HasOne<Diaria>()
                    .WithMany()
                    .OnDelete(DeleteBehavior.NoAction
            )
        );
    }
}