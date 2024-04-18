using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlannedTraining.Server.Migrations
{
    public partial class ajuste_Pk_treino : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExercicioId",
                table: "Treinos",
                newName: "AlunoId");

            migrationBuilder.RenameColumn(
                name: "AlunoId",
                table: "Exercicios",
                newName: "ExwecicioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AlunoId",
                table: "Treinos",
                newName: "ExercicioId");

            migrationBuilder.RenameColumn(
                name: "ExwecicioId",
                table: "Exercicios",
                newName: "AlunoId");
        }
    }
}
