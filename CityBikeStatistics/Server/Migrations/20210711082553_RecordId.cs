using Microsoft.EntityFrameworkCore.Migrations;

namespace CityBikeStatistics.Server.Migrations
{
    public partial class RecordId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CityBikeData_Id",
                table: "CityBikeData");

            migrationBuilder.AlterColumn<decimal>(
                name: "CoveredDistance",
                table: "CityBikeData",
                type: "Decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "RecordId",
                table: "CityBikeData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CityBikeData_RecordId",
                table: "CityBikeData",
                column: "RecordId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CityBikeData_RecordId",
                table: "CityBikeData");

            migrationBuilder.DropColumn(
                name: "RecordId",
                table: "CityBikeData");

            migrationBuilder.AlterColumn<decimal>(
                name: "CoveredDistance",
                table: "CityBikeData",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_CityBikeData_Id",
                table: "CityBikeData",
                column: "Id",
                unique: true);
        }
    }
}
