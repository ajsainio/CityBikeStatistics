using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorTest.Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CityBikeData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Departure = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Return = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartureStationId = table.Column<int>(type: "int", nullable: false),
                    DepartureStationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReturnStationId = table.Column<int>(type: "int", nullable: true),
                    ReturnStationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoveredDistance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityBikeData", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityBikeData_Id",
                table: "CityBikeData",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityBikeData");
        }
    }
}
