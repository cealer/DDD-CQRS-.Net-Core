using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EVALUACION.INFRASTRUCTURE.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "EVALUACION");

            migrationBuilder.CreateSequence(
                name: "HP_OC_DET_seq",
                schema: "EVALUACION",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "HP_OC_seq",
                schema: "EVALUACION",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "HP_OC",
                schema: "EVALUACION",
                columns: table => new
                {
                    ID_HP_OC = table.Column<int>(nullable: false),
                    N_ID_ESTADO = table.Column<int>(nullable: false),
                    N_ID_PROVEEDOR = table.Column<int>(nullable: false),
                    FECHA_REGISTRO = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_HP_OC", x => x.ID_HP_OC);
                });

            migrationBuilder.CreateTable(
                name: "HP_OC_DET",
                schema: "EVALUACION",
                columns: table => new
                {
                    N_ID_OC_DET = table.Column<int>(nullable: false),
                    ID_HP_OC = table.Column<int>(nullable: false),
                    ID_PRODUCTO = table.Column<int>(nullable: false),
                    TURNO = table.Column<string>(type: "VARCHAR(1)", nullable: false),
                    FECHA_ESTIMADA = table.Column<DateTime>(nullable: false),
                    OBSERVACION = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    ID_FABRICANTE = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HP_OC_DET", x => x.N_ID_OC_DET);
                    table.ForeignKey(
                        name: "FK_HP_OC_DET_HP_OC_ID_HP_OC",
                        column: x => x.ID_HP_OC,
                        principalSchema: "EVALUACION",
                        principalTable: "HP_OC",
                        principalColumn: "ID_HP_OC",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HP_OC_DET_ID_HP_OC",
                schema: "EVALUACION",
                table: "HP_OC_DET",
                column: "ID_HP_OC");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HP_OC_DET",
                schema: "EVALUACION");

            migrationBuilder.DropTable(
                name: "HP_OC",
                schema: "EVALUACION");

            migrationBuilder.DropSequence(
                name: "HP_OC_DET_seq",
                schema: "EVALUACION");

            migrationBuilder.DropSequence(
                name: "HP_OC_seq",
                schema: "EVALUACION");
        }
    }
}
