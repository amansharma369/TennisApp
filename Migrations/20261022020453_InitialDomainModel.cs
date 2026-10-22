using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TennisScoreApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialDomainModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    StatisticsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aces = table.Column<int>(type: "int", nullable: false),
                    ServiceWinners = table.Column<int>(type: "int", nullable: false),
                    Winners = table.Column<int>(type: "int", nullable: false),
                    ForcedErrors = table.Column<int>(type: "int", nullable: false),
                    UnforcedErrors = table.Column<int>(type: "int", nullable: false),
                    DoubleFaults = table.Column<int>(type: "int", nullable: false),
                    TotalPointsWon = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.StatisticsId);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatisticsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Players_Statistics_StatisticsId",
                        column: x => x.StatisticsId,
                        principalTable: "Statistics",
                        principalColumn: "StatisticsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    MatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Player1PlayerId = table.Column<int>(type: "int", nullable: false),
                    Player2PlayerId = table.Column<int>(type: "int", nullable: false),
                    CurrentServerPlayerId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    WinnerPlayerId = table.Column<int>(type: "int", nullable: true),
                    Player1SetsWon = table.Column<int>(type: "int", nullable: false),
                    Player2SetsWon = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.MatchId);
                    table.ForeignKey(
                        name: "FK_Matches_Players_CurrentServerPlayerId",
                        column: x => x.CurrentServerPlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId");
                    table.ForeignKey(
                        name: "FK_Matches_Players_Player1PlayerId",
                        column: x => x.Player1PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId");
                    table.ForeignKey(
                        name: "FK_Matches_Players_Player2PlayerId",
                        column: x => x.Player2PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId");
                    table.ForeignKey(
                        name: "FK_Matches_Players_WinnerPlayerId",
                        column: x => x.WinnerPlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId");
                });

            migrationBuilder.CreateTable(
                name: "Sets",
                columns: table => new
                {
                    SetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Player1PlayerId = table.Column<int>(type: "int", nullable: false),
                    Player2PlayerId = table.Column<int>(type: "int", nullable: false),
                    Player1GamesWon = table.Column<int>(type: "int", nullable: false),
                    Player2GamesWon = table.Column<int>(type: "int", nullable: false),
                    Player1TiebreakPoints = table.Column<int>(type: "int", nullable: false),
                    Player2TiebreakPoints = table.Column<int>(type: "int", nullable: false),
                    IsTiebreak = table.Column<bool>(type: "bit", nullable: false),
                    WinnerPlayerId = table.Column<int>(type: "int", nullable: true),
                    MatchId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sets", x => x.SetId);
                    table.ForeignKey(
                        name: "FK_Sets_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "MatchId");
                    table.ForeignKey(
                        name: "FK_Sets_Players_Player1PlayerId",
                        column: x => x.Player1PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId");
                    table.ForeignKey(
                        name: "FK_Sets_Players_Player2PlayerId",
                        column: x => x.Player2PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId");
                    table.ForeignKey(
                        name: "FK_Sets_Players_WinnerPlayerId",
                        column: x => x.WinnerPlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId");
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Player1PlayerId = table.Column<int>(type: "int", nullable: false),
                    Player2PlayerId = table.Column<int>(type: "int", nullable: false),
                    ServerPlayerId = table.Column<int>(type: "int", nullable: false),
                    WinnerPlayerId = table.Column<int>(type: "int", nullable: true),
                    Player1Points = table.Column<int>(type: "int", nullable: false),
                    Player2Points = table.Column<int>(type: "int", nullable: false),
                    IsDeuce = table.Column<bool>(type: "bit", nullable: false),
                    AdvantagePlayerPlayerId = table.Column<int>(type: "int", nullable: true),
                    SetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Games_Players_AdvantagePlayerPlayerId",
                        column: x => x.AdvantagePlayerPlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId");
                    table.ForeignKey(
                        name: "FK_Games_Players_Player1PlayerId",
                        column: x => x.Player1PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId");
                    table.ForeignKey(
                        name: "FK_Games_Players_Player2PlayerId",
                        column: x => x.Player2PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId");
                    table.ForeignKey(
                        name: "FK_Games_Players_ServerPlayerId",
                        column: x => x.ServerPlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId");
                    table.ForeignKey(
                        name: "FK_Games_Players_WinnerPlayerId",
                        column: x => x.WinnerPlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId");
                    table.ForeignKey(
                        name: "FK_Games_Sets_SetId",
                        column: x => x.SetId,
                        principalTable: "Sets",
                        principalColumn: "SetId");
                });

            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    PointId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServerPlayerId = table.Column<int>(type: "int", nullable: false),
                    WinnerPlayerId = table.Column<int>(type: "int", nullable: false),
                    Outcome = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points", x => x.PointId);
                    table.ForeignKey(
                        name: "FK_Points_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId");
                    table.ForeignKey(
                        name: "FK_Points_Players_ServerPlayerId",
                        column: x => x.ServerPlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId");
                    table.ForeignKey(
                        name: "FK_Points_Players_WinnerPlayerId",
                        column: x => x.WinnerPlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_AdvantagePlayerPlayerId",
                table: "Games",
                column: "AdvantagePlayerPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Player1PlayerId",
                table: "Games",
                column: "Player1PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Player2PlayerId",
                table: "Games",
                column: "Player2PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_ServerPlayerId",
                table: "Games",
                column: "ServerPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_SetId",
                table: "Games",
                column: "SetId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_WinnerPlayerId",
                table: "Games",
                column: "WinnerPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_CurrentServerPlayerId",
                table: "Matches",
                column: "CurrentServerPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Player1PlayerId",
                table: "Matches",
                column: "Player1PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Player2PlayerId",
                table: "Matches",
                column: "Player2PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_WinnerPlayerId",
                table: "Matches",
                column: "WinnerPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_StatisticsId",
                table: "Players",
                column: "StatisticsId");

            migrationBuilder.CreateIndex(
                name: "IX_Points_GameId",
                table: "Points",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Points_ServerPlayerId",
                table: "Points",
                column: "ServerPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Points_WinnerPlayerId",
                table: "Points",
                column: "WinnerPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sets_MatchId",
                table: "Sets",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Sets_Player1PlayerId",
                table: "Sets",
                column: "Player1PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sets_Player2PlayerId",
                table: "Sets",
                column: "Player2PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sets_WinnerPlayerId",
                table: "Sets",
                column: "WinnerPlayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Points");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Sets");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Statistics");
        }
    }
}
