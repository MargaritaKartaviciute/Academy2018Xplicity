using Microsoft.EntityFrameworkCore.Migrations;

namespace BountyHuntersAPI.Migrations
{
    public partial class updatetournament : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "matchesCount",
                table: "Tournaments",
                newName: "MatchesCount");

            migrationBuilder.RenameColumn(
                name: "whichMatch",
                table: "Matches",
                newName: "WhichMatch");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MatchesCount",
                table: "Tournaments",
                newName: "matchesCount");

            migrationBuilder.RenameColumn(
                name: "WhichMatch",
                table: "Matches",
                newName: "whichMatch");
        }
    }
}
