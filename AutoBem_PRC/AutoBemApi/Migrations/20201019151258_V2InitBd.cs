using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoBemApi.Migrations
{
    public partial class V2InitBd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Presente",
                table: "Frequencias",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Presente",
                table: "Frequencias");
        }
    }
}
