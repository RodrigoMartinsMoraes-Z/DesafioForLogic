using Microsoft.EntityFrameworkCore.Migrations;

namespace Desafio4Logic.Context.Migrations
{
    public partial class MotivoAvaliacaoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.AddColumn<string>(
                name: "Motivo",
                table: "Avaliacoes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropColumn(
                name: "Motivo",
                table: "Avaliacoes");
        }
    }
}
