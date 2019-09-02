using Microsoft.EntityFrameworkCore.Migrations;

namespace MyJukeBox.Migrations
{
    public partial class ReleaseTitleAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Releases",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Releases");
        }
    }
}
