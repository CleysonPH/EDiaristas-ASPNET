using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDiaristas.Core.Data.Migrations
{
    public partial class CreateCidadeAtendidaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CidadeAtendida",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoIbge = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CidadeAtendida", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CidadeAtendidaUsuario",
                columns: table => new
                {
                    CidadesAtendidasId = table.Column<int>(type: "int", nullable: false),
                    UsuariosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CidadeAtendidaUsuario", x => new { x.CidadesAtendidasId, x.UsuariosId });
                    table.ForeignKey(
                        name: "FK_CidadeAtendidaUsuario_AspNetUsers_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CidadeAtendidaUsuario_CidadeAtendida_CidadesAtendidasId",
                        column: x => x.CidadesAtendidasId,
                        principalTable: "CidadeAtendida",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CidadeAtendidaUsuario_UsuariosId",
                table: "CidadeAtendidaUsuario",
                column: "UsuariosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CidadeAtendidaUsuario");

            migrationBuilder.DropTable(
                name: "CidadeAtendida");
        }
    }
}
