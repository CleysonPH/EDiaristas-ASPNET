﻿// <auto-generated />
using System;
using EDiaristas.Core.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EDiaristas.Core.Data.Migrations
{
    [DbContext(typeof(EDiaristasDbContext))]
    [Migration("20221030000842_CreatePasswordResetTokensTable")]
    partial class CreatePasswordResetTokensTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Candidaturas", b =>
                {
                    b.Property<int>("CandidatosId")
                        .HasColumnType("int");

                    b.Property<int>("CandidaturasId")
                        .HasColumnType("int");

                    b.HasKey("CandidatosId", "CandidaturasId");

                    b.HasIndex("CandidaturasId");

                    b.ToTable("Candidaturas");
                });

            modelBuilder.Entity("CidadeAtendidaUsuario", b =>
                {
                    b.Property<int>("CidadesAtendidasId")
                        .HasColumnType("int");

                    b.Property<int>("UsuariosId")
                        .HasColumnType("int");

                    b.HasKey("CidadesAtendidasId", "UsuariosId");

                    b.HasIndex("UsuariosId");

                    b.ToTable("CidadeAtendidaUsuario");
                });

            modelBuilder.Entity("EDiaristas.Core.Models.Avaliacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AvaliadoId")
                        .HasColumnType("int");

                    b.Property<int?>("AvaliadorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("DiariaId")
                        .HasColumnType("int");

                    b.Property<double>("Nota")
                        .HasColumnType("float");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Visibilidade")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AvaliadoId");

                    b.HasIndex("AvaliadorId");

                    b.HasIndex("DiariaId");

                    b.ToTable("Avaliacoes", (string)null);
                });

            modelBuilder.Entity("EDiaristas.Core.Models.CidadeAtendida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("CodigoIbge")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.HasKey("Id");

                    b.ToTable("CidadeAtendida", (string)null);
                });

            modelBuilder.Entity("EDiaristas.Core.Models.Diaria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("CodigoIbge")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Complemento")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataAtendimento")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DiaristaId")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MotivoCancelamento")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Observacoes")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal>("Preco")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("QuantidadeBanheiros")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeCozinhas")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeOutros")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeQuartos")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeQuintais")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeSalas")
                        .HasColumnType("int");

                    b.Property<int>("ServicoId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<int>("TempoAtendimento")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ValorComissao")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("DiaristaId");

                    b.HasIndex("ServicoId");

                    b.ToTable("Diarias", (string)null);
                });

            modelBuilder.Entity("EDiaristas.Core.Models.EnderecoDiarista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Complemento")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Enderecos", (string)null);
                });

            modelBuilder.Entity("EDiaristas.Core.Models.InvalidatedToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("InvalidatedTokens", (string)null);
                });

            modelBuilder.Entity("EDiaristas.Core.Models.Pagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DiariaId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("TransacaoId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Valor")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("DiariaId");

                    b.ToTable("Pagamentos", (string)null);
                });

            modelBuilder.Entity("EDiaristas.Core.Models.PasswordResetToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("IssuedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("PasswordResetTokens", (string)null);
                });

            modelBuilder.Entity("EDiaristas.Core.Models.Servico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("HorasBanheiro")
                        .HasColumnType("int");

                    b.Property<int>("HorasCozinha")
                        .HasColumnType("int");

                    b.Property<int>("HorasOutros")
                        .HasColumnType("int");

                    b.Property<int>("HorasQuarto")
                        .HasColumnType("int");

                    b.Property<int>("HorasQuintal")
                        .HasColumnType("int");

                    b.Property<int>("HorasSala")
                        .HasColumnType("int");

                    b.Property<string>("Icone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("PorcentagemComissao")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Posicao")
                        .HasColumnType("int");

                    b.Property<int>("QtdHoras")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorBanheiro")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorCozinha")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorMinimo")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorOutros")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorQuarto")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorQuintal")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorSala")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Servicos", (string)null);
                });

            modelBuilder.Entity("EDiaristas.Core.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ChavePix")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Cpf")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("FotoDocumento")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("FotoUsuario")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("Nascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double?>("Reputacao")
                        .HasPrecision(2, 1)
                        .HasColumnType("float(2)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Telefone")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("TipoUsuario")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId")
                        .IsUnique()
                        .HasFilter("[EnderecoId] IS NOT NULL");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("Candidaturas", b =>
                {
                    b.HasOne("EDiaristas.Core.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("CandidatosId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("EDiaristas.Core.Models.Diaria", null)
                        .WithMany()
                        .HasForeignKey("CandidaturasId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("CidadeAtendidaUsuario", b =>
                {
                    b.HasOne("EDiaristas.Core.Models.CidadeAtendida", null)
                        .WithMany()
                        .HasForeignKey("CidadesAtendidasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EDiaristas.Core.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UsuariosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EDiaristas.Core.Models.Avaliacao", b =>
                {
                    b.HasOne("EDiaristas.Core.Models.Usuario", "Avaliado")
                        .WithMany()
                        .HasForeignKey("AvaliadoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("EDiaristas.Core.Models.Usuario", "Avaliador")
                        .WithMany()
                        .HasForeignKey("AvaliadorId");

                    b.HasOne("EDiaristas.Core.Models.Diaria", "Diaria")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("DiariaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Avaliado");

                    b.Navigation("Avaliador");

                    b.Navigation("Diaria");
                });

            modelBuilder.Entity("EDiaristas.Core.Models.Diaria", b =>
                {
                    b.HasOne("EDiaristas.Core.Models.Usuario", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EDiaristas.Core.Models.Usuario", "Diarista")
                        .WithMany()
                        .HasForeignKey("DiaristaId");

                    b.HasOne("EDiaristas.Core.Models.Servico", "Servico")
                        .WithMany()
                        .HasForeignKey("ServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Diarista");

                    b.Navigation("Servico");
                });

            modelBuilder.Entity("EDiaristas.Core.Models.Pagamento", b =>
                {
                    b.HasOne("EDiaristas.Core.Models.Diaria", "Diaria")
                        .WithMany("Pagamentos")
                        .HasForeignKey("DiariaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diaria");
                });

            modelBuilder.Entity("EDiaristas.Core.Models.Usuario", b =>
                {
                    b.HasOne("EDiaristas.Core.Models.EnderecoDiarista", "Endereco")
                        .WithOne()
                        .HasForeignKey("EDiaristas.Core.Models.Usuario", "EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("EDiaristas.Core.Models.Diaria", b =>
                {
                    b.Navigation("Avaliacoes");

                    b.Navigation("Pagamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
