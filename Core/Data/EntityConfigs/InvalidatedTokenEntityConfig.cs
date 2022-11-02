using EDiaristas.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDiaristas.Core.Data.EntityConfigs;

public class InvalidatedTokenEntityConfig : BaseModelEntityConfig<InvalidatedToken>
{
    public override void Configure(EntityTypeBuilder<InvalidatedToken> builder)
    {
        base.Configure(builder);
        builder.ToTable("InvalidatedTokens");

        builder.Property(x => x.Token)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.ExpirationDate)
            .IsRequired();
    }
}