using Microsoft.EntityFrameworkCore.Migrations;

namespace NextMassConsole.Migrations
{
    public partial class Correctlattitudetolatitudemisspelling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DefaultLocation_Lattitude",
                table: "Users",
                newName: "DefaultLocation_Latitude");

            migrationBuilder.RenameColumn(
                name: "Location_Lattitude",
                table: "Churches",
                newName: "Location_Latitude");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DefaultLocation_Latitude",
                table: "Users",
                newName: "DefaultLocation_Lattitude");

            migrationBuilder.RenameColumn(
                name: "Location_Latitude",
                table: "Churches",
                newName: "Location_Lattitude");
        }
    }
}
