using EDiaristas.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDiaristas.Core.Data.EntityConfigs;

public class InvalidatedTokenEntityConfig : IEntityTypeConfiguration<InvalidatedToken>
{
    public void Configure(EntityTypeBuilder<InvalidatedToken> builder)
    {
        builder.ToTable("InvalidatedTokens");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Token)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.ExpirationDate)
            .IsRequired();
    }
}