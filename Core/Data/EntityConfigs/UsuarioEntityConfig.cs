using EDiaristas.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDiaristas.Core.Data.EntityConfigs;

public class UsuarioEntityConfig : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuarios");

        builder.HasKey(x => x.Id);

        builder.Property(u => u.NomeCompleto)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(u => u.Email)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(u => u.Senha)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(u => u.Cpf)
            .HasMaxLength(11)
            .IsRequired(false);

        builder.Property(u => u.Nascimento)
            .IsRequired(false);

        builder.Property(u => u.Telefone)
            .HasMaxLength(11)
            .IsRequired(false);

        builder.Property(u => u.Reputacao)
            .HasPrecision(2, 1)
            .IsRequired(false);

        builder.Property(u => u.ChavePix)
            .HasMaxLength(255)
            .IsRequired(false);

        builder.Property(u => u.TipoUsuario)
            .IsRequired()
            .HasMaxLength(8)
            .HasConversion(
                v => v.ToTipoUsuarioName(),
                v => v.ToTipoUsuario()
            );

        builder.HasOne(u => u.Endereco)
            .WithOne()
            .HasForeignKey<Usuario>(u => u.EnderecoId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);

        builder.Property(u => u.FotoDocumento)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(u => u.FotoUsuario)
            .HasMaxLength(500)
            .IsRequired(false);
    }
}