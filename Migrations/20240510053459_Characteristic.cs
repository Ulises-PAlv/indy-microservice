using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace indy_microservice.Migrations
{
    public partial class Characteristic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characteristics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Boost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characteristics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BotPilotCharacteristic",
                columns: table => new
                {
                    BotPilotsId = table.Column<int>(type: "int", nullable: false),
                    CharacteristicsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BotPilotCharacteristic", x => new { x.BotPilotsId, x.CharacteristicsId });
                    table.ForeignKey(
                        name: "FK_BotPilotCharacteristic_BotPilots_BotPilotsId",
                        column: x => x.BotPilotsId,
                        principalTable: "BotPilots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BotPilotCharacteristic_Characteristics_CharacteristicsId",
                        column: x => x.CharacteristicsId,
                        principalTable: "Characteristics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BotPilotCharacteristic_CharacteristicsId",
                table: "BotPilotCharacteristic",
                column: "CharacteristicsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BotPilotCharacteristic");

            migrationBuilder.DropTable(
                name: "Characteristics");
        }
    }
}
