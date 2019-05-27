using Microsoft.EntityFrameworkCore.Migrations;

namespace BountyHuntersAPI.Migrations
{
    public partial class newplayerfeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Players");

            migrationBuilder.AddColumn<int>(
                name: "DefeatsCount",
                table: "Players",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MatchsCount",
                table: "Players",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WinningsCount",
                table: "Players",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefeatsCount",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "MatchsCount",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "WinningsCount",
                table: "Players");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Players",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Players",
                nullable: true);
        }
    }
}
