using Microsoft.EntityFrameworkCore.Migrations;

namespace TriviaServer.Migrations
{
    public partial class I5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "ForeignKey_Category_Game",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_GameroomId",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Categories",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoryGame",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryGame", x => new { x.GameId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_CategoryGame_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryGame_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_GameId",
                table: "Categories",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryGame_CategoryId",
                table: "CategoryGame",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Games_GameId",
                table: "Categories",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Games_GameId",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "CategoryGame");

            migrationBuilder.DropIndex(
                name: "IX_Categories_GameId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Categories");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_GameroomId",
                table: "Categories",
                column: "GameroomId");

            migrationBuilder.AddForeignKey(
                name: "ForeignKey_Category_Game",
                table: "Categories",
                column: "GameroomId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
