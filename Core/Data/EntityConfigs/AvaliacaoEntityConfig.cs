using EDiaristas.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDiaristas.Core.Data.EntityConfigs;

public class AvaliacaoEntityConfig : IEntityTypeConfiguration<Avaliacao>
{
    public void Configure(EntityTypeBuilder<Avaliacao> builder)
    {
        builder.ToTable("Avaliacoes");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Descricao)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(a => a.Nota)
            .IsRequired();

        builder.Property(a => a.Visibilidade)
            .IsRequired();

        builder.HasOne(a => a.Diaria)
            .WithMany(d => d.Avaliacoes)
            .HasForeignKey(a => a.DiariaId)
            .IsRequired();

        builder.HasOne(a => a.Avaliador)
            .WithMany()
            .HasForeignKey(a => a.AvaliadorId)
            .IsRequired(false);

        builder.HasOne(a => a.Avaliado)
            .WithMany()
            .HasForeignKey(a => a.AvaliadoId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
    }
}