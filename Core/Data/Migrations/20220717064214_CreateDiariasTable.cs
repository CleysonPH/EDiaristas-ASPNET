using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDiaristas.Core.Data.Migrations
{
    public partial class CreateDiariasTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diarias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataAtendimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TempoAtendimento = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ValorComissao = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    CodigoIbge = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    QuantidadeQuartos = table.Column<int>(type: "int", nullable: false),
                    QuantidadeSalas = table.Column<int>(type: "int", nullable: false),
                    QuantidadeCozinhas = table.Column<int>(type: "int", nullable: false),
                    QuantidadeBanheiros = table.Column<int>(type: "int", nullable: false),
                    QuantidadeQuintais = table.Column<int>(type: "int", nullable: false),
                    QuantidadeOutros = table.Column<int>(type: "int", nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MotivoCancelamento = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    DiaristaId = table.Column<int>(type: "int", nullable: true),
                    ServicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diarias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diarias_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diarias_Usuarios_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diarias_Usuarios_DiaristaId",
                        column: x => x.DiaristaId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Candidaturas",
                columns: table => new
                {
                    CandidatosId = table.Column<int>(type: "int", nullable: false),
                    CandidaturasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidaturas", x => new { x.CandidatosId, x.CandidaturasId });
                    table.ForeignKey(
                        name: "FK_Candidaturas_Diarias_CandidaturasId",
                        column: x => x.CandidaturasId,
                        principalTable: "Diarias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Candidaturas_Usuarios_CandidatosId",
                        column: x => x.CandidatosId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidaturas_CandidaturasId",
                table: "Candidaturas",
                column: "CandidaturasId");

            migrationBuilder.CreateIndex(
                name: "IX_Diarias_ClienteId",
                table: "Diarias",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Diarias_DiaristaId",
                table: "Diarias",
                column: "DiaristaId");

            migrationBuilder.CreateIndex(
                name: "IX_Diarias_ServicoId",
                table: "Diarias",
                column: "ServicoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidaturas");

            migrationBuilder.DropTable(
                name: "Diarias");
        }
    }
}
