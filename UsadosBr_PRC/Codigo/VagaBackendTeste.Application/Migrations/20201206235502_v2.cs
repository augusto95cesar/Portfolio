using Microsoft.EntityFrameworkCore.Migrations;

namespace VagaBackendTeste.Application.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modelos_Modelos_CodigoMarca",
                table: "Modelos");

            migrationBuilder.DropForeignKey(
                name: "FK_Modelos_Marcas_MarcaId",
                table: "Modelos");

            migrationBuilder.DropIndex(
                name: "IX_Modelos_MarcaId",
                table: "Modelos");

            migrationBuilder.DropColumn(
                name: "MarcaId",
                table: "Modelos");

            migrationBuilder.AddForeignKey(
                name: "FK_Modelos_Marcas_CodigoMarca",
                table: "Modelos",
                column: "CodigoMarca",
                principalTable: "Marcas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modelos_Marcas_CodigoMarca",
                table: "Modelos");

            migrationBuilder.AddColumn<int>(
                name: "MarcaId",
                table: "Modelos",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_MarcaId",
                table: "Modelos",
                column: "MarcaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Modelos_Modelos_CodigoMarca",
                table: "Modelos",
                column: "CodigoMarca",
                principalTable: "Modelos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Modelos_Marcas_MarcaId",
                table: "Modelos",
                column: "MarcaId",
                principalTable: "Marcas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
