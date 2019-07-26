using Microsoft.EntityFrameworkCore.Migrations;

namespace NextMassConsole.Migrations
{
    public partial class ChangepropLocationtonameCoordinatesinChurch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location_Longitude",
                table: "Churches",
                newName: "Coordinates_Longitude");

            migrationBuilder.RenameColumn(
                name: "Location_Latitude",
                table: "Churches",
                newName: "Coordinates_Latitude");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Coordinates_Longitude",
                table: "Churches",
                newName: "Location_Longitude");

            migrationBuilder.RenameColumn(
                name: "Coordinates_Latitude",
                table: "Churches",
                newName: "Location_Latitude");
        }
    }
}
