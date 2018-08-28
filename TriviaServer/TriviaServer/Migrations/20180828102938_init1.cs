using Microsoft.EntityFrameworkCore.Migrations;

namespace TriviaServer.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Players_GameroomId",
                table: "Players",
                column: "GameroomId");

            migrationBuilder.AddForeignKey(
                name: "ForeignKey_Player_Game",
                table: "Players",
                column: "GameroomId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "ForeignKey_Player_Game",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_GameroomId",
                table: "Players");
        }
    }
}
