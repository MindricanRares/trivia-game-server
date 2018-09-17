using Microsoft.EntityFrameworkCore.Migrations;

namespace TriviaServer.Migrations
{
    public partial class I10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE TRIGGER IncrementCategoryUses ON dbo.CategoryGames
                    AFTER INSERT
                    AS
                    BEGIN
                    Update dbo.Categories set NumberOfUses = NumberOfUses + 1
                    Where CategoryId = (select CategoryId from inserted)
                    END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER IncrementCategoryUses");
        }
    }
}
