using Microsoft.EntityFrameworkCore.Migrations;

namespace NextMassConsole.Migrations
{
    public partial class Convertlatandlongtodoubles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "DefaultLocation_Longitude",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<double>(
                name: "DefaultLocation_Lattitude",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<double>(
                name: "Location_Longitude",
                table: "Churches",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<double>(
                name: "Location_Lattitude",
                table: "Churches",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DefaultLocation_Longitude",
                table: "Users",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "DefaultLocation_Lattitude",
                table: "Users",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "Location_Longitude",
                table: "Churches",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "Location_Lattitude",
                table: "Churches",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
