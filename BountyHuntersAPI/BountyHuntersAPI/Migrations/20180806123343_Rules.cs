using Microsoft.EntityFrameworkCore.Migrations;

namespace BountyHuntersAPI.Migrations
{
    public partial class Rules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GoalsToWin",
                table: "Tournaments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberGoals",
                table: "Tournaments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlayersInKnockout",
                table: "Tournaments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlayersInTeam",
                table: "Tournaments",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoalsToWin",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "NumberGoals",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "PlayersInKnockout",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "PlayersInTeam",
                table: "Tournaments");
        }
    }
}
