using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BountyHuntersAPI.Migrations
{
    public partial class updatemodelsformatchgeneration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "matchesCount",
                table: "Tournaments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WinnerId",
                table: "Matches",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "whichMatch",
                table: "Matches",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MatchEntry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Score = table.Column<int>(nullable: false),
                    MatchPlayerId = table.Column<int>(nullable: true),
                    ParentMatchId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchEntry_Players_MatchPlayerId",
                        column: x => x.MatchPlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchEntry_Matches_ParentMatchId",
                        column: x => x.ParentMatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_WinnerId",
                table: "Matches",
                column: "WinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchEntry_MatchPlayerId",
                table: "MatchEntry",
                column: "MatchPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchEntry_ParentMatchId",
                table: "MatchEntry",
                column: "ParentMatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_WinnerId",
                table: "Matches",
                column: "WinnerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_WinnerId",
                table: "Matches");

            migrationBuilder.DropTable(
                name: "MatchEntry");

            migrationBuilder.DropIndex(
                name: "IX_Matches_WinnerId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "matchesCount",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "WinnerId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "whichMatch",
                table: "Matches");
        }
    }
}
