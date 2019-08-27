using Microsoft.EntityFrameworkCore.Migrations;

namespace GifFind.API.Migrations
{
    public partial class UpdatedHelperFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SavedImages_CategoryID",
                table: "SavedImages",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UserID",
                table: "Categories",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_AspNetUsers_UserID",
                table: "Categories",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SavedImages_Categories_CategoryID",
                table: "SavedImages",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_AspNetUsers_UserID",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_SavedImages_Categories_CategoryID",
                table: "SavedImages");

            migrationBuilder.DropIndex(
                name: "IX_SavedImages_CategoryID",
                table: "SavedImages");

            migrationBuilder.DropIndex(
                name: "IX_Categories_UserID",
                table: "Categories");
        }
    }
}
