using Microsoft.EntityFrameworkCore.Migrations;

namespace TriviaServer.Migrations
{
    public partial class I7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryGame_Categories_CategoryId",
                table: "CategoryGame");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryGame_Games_GameId",
                table: "CategoryGame");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryGame",
                table: "CategoryGame");

            migrationBuilder.RenameTable(
                name: "CategoryGame",
                newName: "CategoryGames");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryGame_CategoryId",
                table: "CategoryGames",
                newName: "IX_CategoryGames_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryGames",
                table: "CategoryGames",
                columns: new[] { "GameId", "CategoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryGames_Categories_CategoryId",
                table: "CategoryGames",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryGames_Games_GameId",
                table: "CategoryGames",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryGames_Categories_CategoryId",
                table: "CategoryGames");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryGames_Games_GameId",
                table: "CategoryGames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryGames",
                table: "CategoryGames");

            migrationBuilder.RenameTable(
                name: "CategoryGames",
                newName: "CategoryGame");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryGames_CategoryId",
                table: "CategoryGame",
                newName: "IX_CategoryGame_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryGame",
                table: "CategoryGame",
                columns: new[] { "GameId", "CategoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryGame_Categories_CategoryId",
                table: "CategoryGame",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryGame_Games_GameId",
                table: "CategoryGame",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
