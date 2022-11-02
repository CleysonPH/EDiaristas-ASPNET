using EDiaristas.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDiaristas.Core.Data.EntityConfigs;

public class BaseModelEntityConfig<T> : IEntityTypeConfiguration<T> where T : BaseModel
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.CreatedAt)
            .IsRequired(false);

        builder.Property(t => t.UpdatedAt)
            .IsRequired(false);
    }
}