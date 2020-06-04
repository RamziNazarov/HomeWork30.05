using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeWork25._05.Migrations
{
    public partial class AddAdresToClassPokupki : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Pokupki",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Pokupki",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Pokupki");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Pokupki");
        }
    }
}
