using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace indy_microservice.Migrations
{
    public partial class RacingProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Podiums",
                table: "BotPilots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Racing",
                table: "BotPilots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Wins",
                table: "BotPilots",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Podiums",
                table: "BotPilots");

            migrationBuilder.DropColumn(
                name: "Racing",
                table: "BotPilots");

            migrationBuilder.DropColumn(
                name: "Wins",
                table: "BotPilots");
        }
    }
}
