using Microsoft.EntityFrameworkCore.Migrations;

namespace TriviaServer.Migrations
{
    public partial class I6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Games_GameId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_GameId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "GameroomId",
                table: "Categories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameroomId",
                table: "Categories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_GameId",
                table: "Categories",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Games_GameId",
                table: "Categories",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
