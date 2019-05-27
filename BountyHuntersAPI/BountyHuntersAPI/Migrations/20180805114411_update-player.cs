using Microsoft.EntityFrameworkCore.Migrations;

namespace BountyHuntersAPI.Migrations
{
    public partial class updateplayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchEntry_Players_MatchPlayerId",
                table: "MatchEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_WinnerId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Tournaments_TournamentId",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tournaments",
                newName: "TournamentId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Players",
                newName: "PlayerId");

            migrationBuilder.RenameColumn(
                name: "WinnerId",
                table: "Matches",
                newName: "WinnerPlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_WinnerId",
                table: "Matches",
                newName: "IX_Matches_WinnerPlayerId");

            migrationBuilder.RenameColumn(
                name: "MatchPlayerId",
                table: "MatchEntry",
                newName: "MatchPlayerPlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_MatchEntry_MatchPlayerId",
                table: "MatchEntry",
                newName: "IX_MatchEntry_MatchPlayerPlayerId");

            migrationBuilder.AlterColumn<int>(
                name: "TournamentId",
                table: "Players",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchEntry_Players_MatchPlayerPlayerId",
                table: "MatchEntry",
                column: "MatchPlayerPlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_WinnerPlayerId",
                table: "Matches",
                column: "WinnerPlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Tournaments_TournamentId",
                table: "Players",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "TournamentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchEntry_Players_MatchPlayerPlayerId",
                table: "MatchEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_WinnerPlayerId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Tournaments_TournamentId",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "TournamentId",
                table: "Tournaments",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "Players",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "WinnerPlayerId",
                table: "Matches",
                newName: "WinnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_WinnerPlayerId",
                table: "Matches",
                newName: "IX_Matches_WinnerId");

            migrationBuilder.RenameColumn(
                name: "MatchPlayerPlayerId",
                table: "MatchEntry",
                newName: "MatchPlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_MatchEntry_MatchPlayerPlayerId",
                table: "MatchEntry",
                newName: "IX_MatchEntry_MatchPlayerId");

            migrationBuilder.AlterColumn<int>(
                name: "TournamentId",
                table: "Players",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_MatchEntry_Players_MatchPlayerId",
                table: "MatchEntry",
                column: "MatchPlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_WinnerId",
                table: "Matches",
                column: "WinnerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Tournaments_TournamentId",
                table: "Players",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
