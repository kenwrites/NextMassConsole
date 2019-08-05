using Microsoft.EntityFrameworkCore.Migrations;

namespace NextMassConsole.Migrations
{
    public partial class AddNamepropertytoChurch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Churches",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Churches");
        }
    }
}
