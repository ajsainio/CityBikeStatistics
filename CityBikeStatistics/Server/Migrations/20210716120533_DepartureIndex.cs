using Microsoft.EntityFrameworkCore.Migrations;

namespace CityBikeStatistics.Server.Migrations
{
    public partial class DepartureIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CityBikeData_Departure",
                table: "CityBikeData",
                column: "Departure");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CityBikeData_Departure",
                table: "CityBikeData");
        }
    }
}
