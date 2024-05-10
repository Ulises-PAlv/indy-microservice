using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace indy_microservice.Migrations
{
    public partial class UserPilot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "BotPilots",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BotPilots_UserId",
                table: "BotPilots",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BotPilots_Users_UserId",
                table: "BotPilots",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BotPilots_Users_UserId",
                table: "BotPilots");

            migrationBuilder.DropIndex(
                name: "IX_BotPilots_UserId",
                table: "BotPilots");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BotPilots");
        }
    }
}
