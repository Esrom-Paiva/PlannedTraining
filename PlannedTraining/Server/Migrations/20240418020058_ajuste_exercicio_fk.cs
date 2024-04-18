using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlannedTraining.Server.Migrations
{
    public partial class ajuste_exercicio_fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercicios_Treinos_TreinoId",
                table: "Exercicios");

            migrationBuilder.DropColumn(
                name: "ExwecicioId",
                table: "Exercicios");

            migrationBuilder.AlterColumn<long>(
                name: "TreinoId",
                table: "Exercicios",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercicios_Treinos_TreinoId",
                table: "Exercicios",
                column: "TreinoId",
                principalTable: "Treinos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercicios_Treinos_TreinoId",
                table: "Exercicios");

            migrationBuilder.AlterColumn<long>(
                name: "TreinoId",
                table: "Exercicios",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "ExwecicioId",
                table: "Exercicios",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercicios_Treinos_TreinoId",
                table: "Exercicios",
                column: "TreinoId",
                principalTable: "Treinos",
                principalColumn: "Id");
        }
    }
}
