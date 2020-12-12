using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace testedotnet1.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Desenvolvedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desenvolvedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Horas_Trabalhadas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datainicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Datafim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    desenvolvedorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horas_Trabalhadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Horas_Trabalhadas_Desenvolvedores_desenvolvedorId",
                        column: x => x.desenvolvedorId,
                        principalTable: "Desenvolvedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Horas_Trabalhadas_desenvolvedorId",
                table: "Horas_Trabalhadas",
                column: "desenvolvedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Horas_Trabalhadas");

            migrationBuilder.DropTable(
                name: "Desenvolvedores");
        }
    }
}
