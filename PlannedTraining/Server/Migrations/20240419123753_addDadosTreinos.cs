using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlannedTraining.Server.Migrations
{
    public partial class addDadosTreinos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeTreino",
                table: "Treinos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Repeticoes",
                table: "Exercicios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "series",
                table: "Exercicios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Treinos_AlunoId",
                table: "Treinos",
                column: "AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Treinos_Alunos_AlunoId",
                table: "Treinos",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treinos_Alunos_AlunoId",
                table: "Treinos");

            migrationBuilder.DropIndex(
                name: "IX_Treinos_AlunoId",
                table: "Treinos");

            migrationBuilder.DropColumn(
                name: "NomeTreino",
                table: "Treinos");

            migrationBuilder.DropColumn(
                name: "Repeticoes",
                table: "Exercicios");

            migrationBuilder.DropColumn(
                name: "series",
                table: "Exercicios");
        }
    }
}
