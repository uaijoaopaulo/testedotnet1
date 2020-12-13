using Microsoft.EntityFrameworkCore.Migrations;

namespace testedotnet1.Migrations
{
    public partial class alteracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Horas_Trabalhadas_Desenvolvedores_desenvolvedorId",
                table: "Horas_Trabalhadas");

            migrationBuilder.AlterColumn<int>(
                name: "desenvolvedorId",
                table: "Horas_Trabalhadas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Horas_Trabalhadas_Desenvolvedores_desenvolvedorId",
                table: "Horas_Trabalhadas",
                column: "desenvolvedorId",
                principalTable: "Desenvolvedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Horas_Trabalhadas_Desenvolvedores_desenvolvedorId",
                table: "Horas_Trabalhadas");

            migrationBuilder.AlterColumn<int>(
                name: "desenvolvedorId",
                table: "Horas_Trabalhadas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Horas_Trabalhadas_Desenvolvedores_desenvolvedorId",
                table: "Horas_Trabalhadas",
                column: "desenvolvedorId",
                principalTable: "Desenvolvedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
