using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDiaristas.Core.Data.Migrations
{
    public partial class AddAuditableDataInDiariaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Diarias",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Diarias",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Diarias");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Diarias");
        }
    }
}
