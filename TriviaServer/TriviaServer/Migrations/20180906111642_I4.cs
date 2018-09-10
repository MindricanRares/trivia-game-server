using Microsoft.EntityFrameworkCore.Migrations;

namespace TriviaServer.Migrations
{
    public partial class I4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameroomId",
                table: "Categories",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "ForeignKey_Category_Game",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_GameroomId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "GameroomId",
                table: "Categories");
        }
    }
}
