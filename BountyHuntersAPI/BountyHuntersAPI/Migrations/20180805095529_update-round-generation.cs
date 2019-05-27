using Microsoft.EntityFrameworkCore.Migrations;

namespace BountyHuntersAPI.Migrations
{
    public partial class updateroundgeneration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentMatch",
                table: "Tournaments",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentMatch",
                table: "Tournaments");
        }
    }
}
