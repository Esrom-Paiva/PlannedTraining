using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlannedTraining.Server.Migrations
{
    public partial class addDadosTreinosAjuste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "series",
                table: "Exercicios",
                newName: "Series");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Series",
                table: "Exercicios",
                newName: "series");
        }
    }
}
