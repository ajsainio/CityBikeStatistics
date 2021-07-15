using Microsoft.EntityFrameworkCore.Migrations;

namespace CityBikeStatistics.Server.Migrations
{
    public partial class StationIdIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CityBikeData_DepartureStationId",
                table: "CityBikeData",
                column: "DepartureStationId");

            migrationBuilder.CreateIndex(
                name: "IX_CityBikeData_ReturnStationId",
                table: "CityBikeData",
                column: "ReturnStationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CityBikeData_DepartureStationId",
                table: "CityBikeData");

            migrationBuilder.DropIndex(
                name: "IX_CityBikeData_ReturnStationId",
                table: "CityBikeData");
        }
    }
}
