using Microsoft.EntityFrameworkCore.Migrations;

namespace GifFind.API.Migrations
{
    public partial class Added_SourceID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SourceID",
                table: "SavedImages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SourceID",
                table: "SavedImages");
        }
    }
}
