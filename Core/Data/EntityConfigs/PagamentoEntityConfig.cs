using EDiaristas.Core.Extensions;
using EDiaristas.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDiaristas.Core.Data.EntityConfigs;

public class PagamentoEntityConfig : BaseModelEntityConfig<Pagamento>
{
    public override void Configure(EntityTypeBuilder<Pagamento> builder)
    {
        base.Configure(builder);
        builder.ToTable("Pagamentos");

        builder.Property(p => p.Valor)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(p => p.TransacaoId)
            .IsRequired(false);

        builder.Property(p => p.Status)
            .IsRequired()
            .HasMaxLength(11)
            .HasConversion(
                v => v.ToString(),
                v => v.ParseEnum<PagamentoStatus>()
            );

        builder.HasOne(p => p.Diaria)
            .WithMany(d => d.Pagamentos)
            .HasForeignKey(p => p.DiariaId)
            .IsRequired();
    }
}