using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace indy_microservice.Migrations
{
    public partial class CharacteristicSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Characteristics",
                columns: new[] { "Id", "Boost", "Name" },
                values: new object[,]
                {
                    { 1, 7, "DRS" },
                    { 2, 8, "Wide Spoiler" },
                    { 3, 6, "IA Suspension" },
                    { 4, 7, "Carbon Fiber Brakes" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Characteristics",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Characteristics",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Characteristics",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Characteristics",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
