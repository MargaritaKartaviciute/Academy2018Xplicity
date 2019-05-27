using Microsoft.EntityFrameworkCore.Migrations;

namespace BountyHuntersAPI.Migrations
{
    public partial class removeplayersfrommatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_PlayerAId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_PlayerBId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_PlayerAId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_PlayerBId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "PlayerAId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "PlayerBId",
                table: "Matches");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerAId",
                table: "Matches",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayerBId",
                table: "Matches",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_PlayerAId",
                table: "Matches",
                column: "PlayerAId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_PlayerBId",
                table: "Matches",
                column: "PlayerBId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_PlayerAId",
                table: "Matches",
                column: "PlayerAId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_PlayerBId",
                table: "Matches",
                column: "PlayerBId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
